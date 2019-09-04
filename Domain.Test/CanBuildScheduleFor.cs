using Domain.Test.DSL;
using NUnit.Framework;

namespace Domain.Test
{
    public class CanBuildScheduleFor
    {
        [Test]
        public void OneBacklogItem_OneComponent_OneProgrammer()
        {
            var team = Create.Team.WithProgrammer("Homer", "A");
            var backlog = Create.Backlog
                .WithItem("US1", "A");

            var schedule = new Schedule(backlog, team);

            Assert.That(schedule.AsString(), Looks.LikeSchedule(@"
                |   | Homer |
                | 1 | US1.A |"));
        }

        [Test]
        public void OneBacklogItem_OneComponent_AnotherProgrammer()
        {
            var team = Create.Team.WithProgrammer("Homer", "B");
            var backlog = Create.Backlog
                .WithItem("US1", "B");

            var schedule = new Schedule(backlog, team);

            Assert.That(schedule.AsString(), Looks.LikeSchedule(@"
                |   | Homer |
                | 1 | US1.B |"));
        }

        [Test]
        public void OneBacklogItem_TwoComponents_TwoProgrammers()
        {
            var team = Create.Team
                .WithProgrammer("Homer", "A")
                .WithProgrammer("Marge", "B");
            var backlog = Create.Backlog
                .WithItem("US1", "A", "B");

            var schedule = new Schedule(backlog, team);

            Assert.That(schedule.AsString(), Looks.LikeSchedule(@"
                |   | Homer | Marge |
                | 1 | US1.A | US1.B |"));
        }

        [Test]
        public void TwoBacklogItems_TwoComponents_TwoProgrammers()
        {
            var team = Create.Team
                .WithProgrammer("Homer", "A")
                .WithProgrammer("Marge", "B");
            var backlog = Create.Backlog
                .WithItem("US1", "A")
                .WithItem("US2", "B");

            var schedule = new Schedule(backlog, team);

            Assert.That(schedule.AsString(), Looks.LikeSchedule(@"
                |   | Homer | Marge |
                | 1 | US1.A | US2.B |"));
        }

        [Test]
        public void TwoBacklogItems_OneComponent_OneProgrammer_TwoDays()
        {
            var team = Create.Team
                .WithProgrammer("Homer", "A");
            var backlog = Create.Backlog
                .WithItem("US1", "A")
                .WithItem("US2", "A");

            var schedule = new Schedule(backlog, team);

            Assert.That(schedule.AsString(), Looks.LikeSchedule(@"
                |   | Homer |
                | 1 | US1.A |
                | 2 | US2.A |"));
        }

        [Test]
        public void Scenario1_SpecialistsTeam()
        {
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

            Assert.That(schedule.AsString(), Looks.LikeSchedule(@"
                |   | Homer | Marge | Bart  |
                | 1 | US1.A | US1.B | US3.C |
                | 2 | US1.A | US2.B | US4.C |
                | 3 | US2.A | US2.B | .     |
                | 4 | US3.A | US3.B | .     |
                | 5 | .     | US4.B | .     |
                | 6 | .     | US4.B | .     |"));
        }

        [Test]
        public void Scenario2_TeamWithTShapeProgrammers()
        {
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

            Assert.That(schedule.AsString(), Looks.LikeSchedule(@"
                |   | Homer | Marge | Bart  |
                | 1 | US1.A | US1.A | US3.C |
                | 2 | US1.B | US2.A | US4.C |
                | 3 | US2.B | US2.B | .     |
                | 4 | US3.A | US3.B | .     |
                | 5 | US4.B | US4.B | .     |"));
        }
    }
}