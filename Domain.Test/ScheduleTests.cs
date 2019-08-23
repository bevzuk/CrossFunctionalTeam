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
            var programmer = Create.Programmer.WithName("Homer").WithSkill("A");
            var team = Create.Team.WithProgrammers(programmer).Please;
            var backlog = Create.Backlog
                .With(() => Create.BacklogItem("US1").WithComponent("A"))
                .Please;

            var schedule = new Schedule(backlog, team);
            
            AssertEquals(@"
|   | Homer |
| 1 | US1.A |", schedule);
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
            
            AssertEquals(@"
|   | Homer |
| 1 | US1.B |", schedule);
        }

        private void AssertEquals(string expected, Schedule schedule)
        {
            var trimmedExpected = expected.Replace(" ", "").Trim('\n');
            var trimmedSchedule = schedule.AsString().Replace(" ", "").Trim('\n');
            
            if (trimmedExpected != trimmedSchedule)
            {
                Assert.Fail($@"Expected:
{expected}

Actual:
{schedule.AsString()}");
            }
        }
    }
}