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
            var programmer = Create.Programmer.WithName("Homer").WithSkill("A");
            var team = Create.Team.With(programmer);
            var backlog = Create.Backlog
                .With("US1", "A");

            var schedule = new Schedule(backlog, team);
            
            Assert.That(schedule.AsString(), Looks.Like(@"
                |   | Homer |
                | 1 | US1.A |"));
        }

        [Test]
        public void OneBacklogItem_OneComponent_AnotherProgrammer()
        {
            var programmer = Create.Programmer.WithName("Homer").WithSkill("B");
            var team = Create.Team.With(programmer);
            var backlog = Create.Backlog
                .With("US1","B");

            var schedule = new Schedule(backlog, team);

            Assert.That(schedule.AsString(), Looks.Like(@"
                |   | Homer |
                | 1 | US1.B |"));
        }

        [Test]
        public void OneBacklogItem_TwoComponents_TwoProgrammers()
        {
            var homer = Create.Programmer.WithName("Homer").WithSkill("A");
            var marge = Create.Programmer.WithName("Marge").WithSkill("B");
            var team = Create.Team.With(homer, marge);
            var backlog = Create.Backlog
                .With("US1", "A", "B");

            var schedule = new Schedule(backlog, team);
            
            Assert.That(schedule.AsString(), Looks.Like(@"
                |   | Homer | Marge |
                | 1 | US1.A | US1.B |"));
        }
    }
}