using Domain.TeamWorkStrategy;
using Domain.Test.DSL;
using NUnit.Framework;

namespace Domain.Test.TeamWorkStrategyTests {
    public class WipLimitIgnoreBacklogOrderTeamWorkWorkStrategyTests {
        [Test]
        public void RespectWipLimit() {
            var homer = Create.Programmer.WithSkill("A").Please;
            var marge = Create.Programmer.WithSkill("B").Please;
            var team = Create.Team.With(homer, marge);
            var backlog = Create.Backlog
               .WithItem("US1", "A")
               .WithItem("US2", "B");
            var teamWorkStrategy = new RespectWipLimitIgnoreBacklogOrderTeamWorkStrategy(wipLimit: 1);

            teamWorkStrategy.DistributeWork(backlog, team);

            Assert.That(homer.WorkItem, Looks.LikeWorkItem("US1.A"));
            Assert.False(marge.IsWorking);
        }

        [Test]
        public void MayNotReachWipLimit() {
            var homer = Create.Programmer.WithSkill("A").Please;
            var marge = Create.Programmer.WithSkill("A").Please;
            var team = Create.Team.With(homer, marge);
            var backlog = Create.Backlog
               .WithItem("US1", "A")
               .WithItem("US2", "A");
            var teamWorkStrategy = new RespectWipLimitIgnoreBacklogOrderTeamWorkStrategy(wipLimit: 10);

            teamWorkStrategy.DistributeWork(backlog, team);

            Assert.That(homer.WorkItem, Looks.LikeWorkItem("US1.A"));
            Assert.That(marge.WorkItem, Looks.LikeWorkItem("US2.A"));
        }

        [Test]
        public void IgnoreBacklogOrder() {
            var homer = Create.Programmer.WithSkill("A").Please;
            var marge = Create.Programmer.WithSkill("B").Please;
            var team = Create.Team.With(homer, marge);
            var backlog = Create.Backlog
               .WithItem("US1", "A")
               .WithItem("US2", "A")
               .WithItem("US3", "B");
            var teamWorkStrategy = new RespectWipLimitIgnoreBacklogOrderTeamWorkStrategy(wipLimit: 2);

            teamWorkStrategy.DistributeWork(backlog, team);

            Assert.That(homer.WorkItem, Looks.LikeWorkItem("US1.A"));
            Assert.That(marge.WorkItem, Looks.LikeWorkItem("US3.B"));
        }
    }
}