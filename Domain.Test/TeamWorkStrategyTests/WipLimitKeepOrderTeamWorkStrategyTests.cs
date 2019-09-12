using Domain.TeamWorkStrategy;
using Domain.Test.DSL;
using NUnit.Framework;

namespace Domain.Test.TeamWorkStrategyTests
{
    public class WipLimitKeepOrderTeamWorkStrategyTests
    {
        [Test]
        public void RespectWipLimit1()
        {
            var homer = Create.Programmer.WithSkill("A").Please;
            var marge = Create.Programmer.WithSkill("B").Please;
            var team = Create.Team.With(homer, marge);
            var backlog = Create.Backlog
                .WithItem("US1", "A")
                .WithItem("US2", "B");
            var teamWorkStrategy = new WipLimitKeepOrderTeamWorkStrategy(wipLimit: 1);

            teamWorkStrategy.DistributeWork(backlog, team);

            Assert.AreEqual(new Component("A"), homer.WorkItem.Component);
            Assert.AreEqual(Component.None, marge.WorkItem.Component);
        }
    }
}