using Domain;
using Domain.Test.DSL;
using NUnit.Framework;
using Tests.DSL;

namespace Tests
{
    public class ScheduleTests
    {
        [Test]
        public void OneBacklogItem_OneComponent_OneProgrammer_ScheduleContainsTask()
        {
            var programmer = Create.Programmer.WithSkill("A");
            var team = Create.Team.WithProgrammers(programmer).Please;
            var backlog = Create.Backlog
                .With(() => Create.BacklogItem("US1").WithComponent("A"))
                .Please;

            var schedule = new Schedule(backlog, team);
            
            AssertEquals(@"
|   | A     |
| 1 | US1.A |", schedule);
        }

        private void AssertEquals(string expected, Schedule schedule)
        {
            Assert.AreEqual(expected, schedule.AsString());
        }
    }
}