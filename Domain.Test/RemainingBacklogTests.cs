using Domain.Test.DSL;
using NUnit.Framework;

namespace Domain.Test {
    public class RemainingBacklogTests {
        [Test]
        public void DoesNotContainDoneItems() {
            var backlog = Create.Backlog
               .WithItem("US1", "A")
               .WithItem("US2", "A")
               .Please;
            var programmer = Create.Programmer.WithSkill("A").Please;
            programmer.WorkOn(backlog.Items.First());
            backlog.FinishStartedWork();

            var remainingBacklog = new RemainingBacklog(backlog);

            Assert.That(remainingBacklog.Items.Select(_ => _.Name).ToList(), Is.EqualTo(new[] {"US2"}));
        }
    }
}