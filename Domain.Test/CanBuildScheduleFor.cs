using Domain.Test.DSL;
using NUnit.Framework;
using Tests.DSL;

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
            
            Assert.That(schedule.AsString(), Looks.Like(@"
                |   | Homer |
                | 1 | US1.A |"));
        }

        [Test]
        public void OneBacklogItem_OneComponent_AnotherProgrammer()
        {
            var team = Create.Team.WithProgrammer("Homer", "B");
            var backlog = Create.Backlog
                .WithItem("US1","B");

            var schedule = new Schedule(backlog, team);

            Assert.That(schedule.AsString(), Looks.Like(@"
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
            
            Assert.That(schedule.AsString(), Looks.Like(@"
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
            
            Assert.That(schedule.AsString(), Looks.Like(@"
                |   | Homer | Marge |
                | 1 | US1.A | US2.B |"));
        }
    }
}