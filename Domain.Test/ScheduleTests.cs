using Domain.Test.DSL;
using NUnit.Framework;
using Tests.DSL;

namespace Domain.Test
{
    public class ScheduleTests
    {
        [Test]
        public void OneBacklogItem_OneComponent_OneProgrammer_ScheduleContainsTask()
        {
            var programmer = Create.Programmer.WithName("Homer").WithSkill("A");
            var team = Create.Team.WithProgrammers(programmer).Please;
            var backlog = Create.Backlog
                .With(() => Create.BacklogItem("US1").WithComponent("A"))
                .Please;

            var schedule = new Schedule(backlog, team);
            
            Assert.That(schedule, Looks.Like(@"
|   | Homer |
| 1 | US1.A |"));
        }

        [Test]
        public void OneBacklogItem_OneComponent_AnotherProgrammer_ScheduleContainsTask()
        {
            var programmer = Create.Programmer.WithName("Homer").WithSkill("B");
            var team = Create.Team.WithProgrammers(programmer).Please;
            var backlog = Create.Backlog
                .With(() => Create.BacklogItem("US1").WithComponent("B"))
                .Please;

            var schedule = new Schedule(backlog, team);
            
            Assert.That(schedule, Looks.Like(@"
|   | Homer |
| 1 | US1.B |"));
        }
    }
}