using Domain.Test.DSL;
using NUnit.Framework;

namespace Domain.Test
{
    public class CanCalculateStatisticsFor
    {
        [Test]
        public void OneBacklogItem_OneDay()
        {
            var scheduleData = new[]
            {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(1, 1)));
        }

        [Test]
        public void OneBacklogItem_TwoDays()
        {
            var scheduleData = new[]
            {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A")),
                new ScheduleData(2, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("B"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(1 / 2m, 2)));
        }

        [Test]
        public void OneBacklogItem_ThreeDays()
        {
            var scheduleData = new[]
            {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A")),
                new ScheduleData(2, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("B")),
                new ScheduleData(3, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("C"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(1 / 3m, 3)));
        }

        [Test]
        public void TwoBacklogItems_OneDayEach()
        {
            var scheduleData = new[]
            {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A")),
                new ScheduleData(2, Create.WorkItem.ForBacklogItem("US2").WorkOnComponent("B"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(1, 1)));
        }

        [Test]
        public void TwoBacklogItems_InOneDay()
        {
            var scheduleData = new[]
            {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A")),
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US2").WorkOnComponent("B"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(2, 1)));
        }
    }
}