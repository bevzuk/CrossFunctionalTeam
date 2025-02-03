using Domain.Test.DSL;
using NUnit.Framework;

namespace Domain.Test {
    public class CanCalculateStatisticsFor {
        [Test]
        public void OneBacklogItem_OneDay() {
            var scheduleData = new[] {
                new ScheduleData(
                    day: 1, 
                    workItem: Create.WorkItem
                        .ForBacklogItem("US1")
                        .WorkOnComponent("A")
                )
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics.ThroughputRate, Is.EqualTo(1m), "When one item is completed in one day, throughput should be 1");
            Assert.That(statistics.LeadTime, Is.EqualTo(1m), "When item takes one day to complete, lead time should be 1");
        }

        [Test]
        public void OneBacklogItem_TwoDays() {
            var scheduleData = new[] {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A")),
                new ScheduleData(2, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("B"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(1 / 2m, 2)));
        }

        [Test]
        public void OneBacklogItem_ThreeDays() {
            var scheduleData = new[] {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A")),
                new ScheduleData(2, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("B")),
                new ScheduleData(3, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("C"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(1 / 3m, 3)));
        }

        [Test]
        public void TwoBacklogItems_OneDayEach() {
            var scheduleData = new[] {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A")),
                new ScheduleData(2, Create.WorkItem.ForBacklogItem("US2").WorkOnComponent("B"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(1, 1)));
        }

        [Test]
        public void TwoBacklogItems_InOneDay() {
            var scheduleData = new[] {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A")),
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US2").WorkOnComponent("B"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(2, 1)));
        }

        [Test]
        public void TwoBacklogItems_TwoDaysEach() {
            var scheduleData = new[] {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A")),
                new ScheduleData(2, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A")),
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US2").WorkOnComponent("B")),
                new ScheduleData(2, Create.WorkItem.ForBacklogItem("US2").WorkOnComponent("B"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(1, 2)));
        }

        [Test]
        public void IgnoreIdleWork() {
            var scheduleData = new[] {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A")),
                new ScheduleData(2, Create.WorkItem.ForBacklogItem("US1").NoWork()),
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US2").NoWork()),
                new ScheduleData(2, Create.WorkItem.ForBacklogItem("US2").WorkOnComponent("B"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(1, 1)));
        }

        [Test]
        public void IdleWorkInTheMiddle() {
            var scheduleData = new[] {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A")),
                new ScheduleData(2, Create.WorkItem.ForBacklogItem("US1").NoWork()),
                new ScheduleData(3, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("B"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(1 / 3m, 3)));
        }

        [Test]
        public void Scenario1_SpecialistsTeam() {
            var team = Create.Team
               .WithProgrammer("Homer", "A")
               .WithProgrammer("Marge", "B")
               .WithProgrammer("Bart", "C");
            var backlog = Create.Backlog
               .WithItem("US1", "A", "A", "B")
               .WithItem("US2", "A", "B", "B")
               .WithItem("US3", "A", "B", "C")
               .WithItem("US4", "B", "B", "C");
            var schedule = new Schedule(backlog, team);

            var statistics = schedule.CalculateStatistics();

            Assert.That(statistics, Is.EqualTo(new Statistics(4 / 6m, 3.25m)));
        }

        [Test]
        public void Scenario2_TeamWithTShapeProgrammers() {
            var team = Create.Team
               .WithProgrammer("Homer", "A", "B")
               .WithProgrammer("Marge", "A", "B")
               .WithProgrammer("Bart", "C");
            var backlog = Create.Backlog
               .WithItem("US1", "A", "A", "B")
               .WithItem("US2", "A", "B", "B")
               .WithItem("US3", "A", "B", "C")
               .WithItem("US4", "B", "B", "C");
            var schedule = new Schedule(backlog, team);

            var statistics = schedule.CalculateStatistics();

            Assert.That(statistics, Is.EqualTo(new Statistics(4 / 5m, 3m)));
        }

        [Test]
        public void Scenario4_TeamWithTShapeProgrammers_WipLimit2_IgnoreBacklogOrder() {
            var team = Create.Team
               .WithRespectWipLimitIgnoreBacklogOrderTeamWorkStrategy(wipLimit: 2)
               .WithProgrammer("Homer", "A", "B")
               .WithProgrammer("Marge", "A", "B")
               .WithProgrammer("Bart", "C");
            var backlog = Create.Backlog
               .WithItem("US1", "A", "A", "B")
               .WithItem("US2", "A", "B", "B")
               .WithItem("US3", "A", "B", "C")
               .WithItem("US4", "B", "B", "C");
            var schedule = new Schedule(backlog, team);

            var statistics = schedule.CalculateStatistics();

            Assert.That(statistics, Is.EqualTo(new Statistics(4 / 5m, 2.25m)));
        }

        [Test]
        public void Scenario3_TeamWithTShapeProgrammers_WipLimit_RespectBacklogOrder() {
            var team = Create.Team
               .WithRespectWipLimitRespectBacklogOrderTeamWorkStrategy(2)
               .WithProgrammer("Homer", "A", "B")
               .WithProgrammer("Marge", "A", "B")
               .WithProgrammer("Bart", "C");
            var backlog = Create.Backlog
               .WithItem("US1", "A", "A", "B")
               .WithItem("US2", "A", "B", "B")
               .WithItem("US3", "A", "B", "C")
               .WithItem("US4", "B", "B", "C");
            var schedule = new Schedule(backlog, team);

            var statistics = schedule.CalculateStatistics();

            Assert.That(statistics, Is.EqualTo(new Statistics(4 / 5m, 2m)));
        }

        [Test]
        public void Calculate_EmptySchedule_ThrowsException() {
            var scheduleData = Array.Empty<ScheduleData>();
            
            Assert.That(() => new StatisticsCalculator().Calculate(scheduleData),
                Throws.ArgumentException.With.Message.Contains("Schedule cannot be empty"));
        }

        [Test]
        public void Calculate_AllWorkItemsAreIdle_ReturnsZeroStatistics() {
            var scheduleData = new[] {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").NoWork()),
                new ScheduleData(2, Create.WorkItem.ForBacklogItem("US1").NoWork())
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics.ThroughputRate, Is.EqualTo(0m));
            Assert.That(statistics.LeadTime, Is.EqualTo(0m));
        }
    }
}