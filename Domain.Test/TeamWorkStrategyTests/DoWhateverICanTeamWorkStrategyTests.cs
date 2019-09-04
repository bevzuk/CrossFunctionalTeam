using Domain.TeamWorkStrategy;
using Domain.Test.DSL;
using NUnit.Framework;

namespace Domain.Test.TeamWorkStrategyTests
{
    public class DoWhateverICanTeamWorkStrategyTests
    {
        [Test]
        public void CanChooseWork()
        {
            var programmer = Create.Programmer.WithSkill("A").Please;
            var backlog = Create.Backlog.WithItem("US1", "A", "B");
            var teamWorkStrategy = new DoWhateverICanTeamWorkStrategy();

            teamWorkStrategy.ChooseWork(backlog, programmer);

            Assert.AreEqual(new Component("A"), programmer.WorkItem.Component);
        }

        [Test]
        public void CanChooseSecondItem()
        {
            var programmer = Create.Programmer.WithSkill("A").Please;
            var backlog = Create.Backlog
                .WithItem("US1", "B")
                .WithItem("US2", "A");
            var teamWorkStrategy = new DoWhateverICanTeamWorkStrategy();

            teamWorkStrategy.ChooseWork(backlog, programmer);

            Assert.AreEqual(Create.WorkItem.ForBacklogItem("US2", "A").WorkOnComponent("A").Please,
                programmer.WorkItem);
        }

        [Test]
        public void WhenNoWork_DoNothing()
        {
            var programmer = Create.Programmer.WithSkill("A").Please;
            var backlog = Create.Backlog.WithItem("US1", "B");
            var teamWorkStrategy = new DoWhateverICanTeamWorkStrategy();

            teamWorkStrategy.ChooseWork(backlog, programmer);

            Assert.AreEqual(Component.None, programmer.WorkItem.Component);
        }

        [Test]
        public void When2ProgrammersDo1PBI_Programmer2HasDoesNothing()
        {
            var programmer1 = Create.Programmer.WithSkill("A").Please;
            var programmer2 = Create.Programmer.WithSkill("A").Please;
            var backlog = Create.Backlog.WithItem("US1", "A");
            var teamWorkStrategy = new DoWhateverICanTeamWorkStrategy();

            teamWorkStrategy.ChooseWork(backlog, programmer1);
            teamWorkStrategy.ChooseWork(backlog, programmer2);

            Assert.AreEqual(new Component("A"), programmer1.WorkItem.Component);
            Assert.AreEqual(Component.None, programmer2.WorkItem.Component);
        }
    }
}