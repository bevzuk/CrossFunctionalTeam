using System;
using System.Linq;

namespace Domain.TeamWorkStrategy
{
    public class WipLimitKeepOrderTeamWorkStrategy : RespectBacklogOrderTeamStrategy, ITeamWorkStrategy
    {
        private readonly int wipLimit;

        public WipLimitKeepOrderTeamWorkStrategy(int wipLimit)
        {
            this.wipLimit = wipLimit;
        }

        public void DistributeWork(Backlog backlog, Team team)
        {
            var remainingWork = wipLimit;
            foreach (var programmer in team.Members)
            {
                if (remainingWork == 0)
                {
                    programmer.DoNothing();
                    continue;
                }

                ChooseWork(backlog, programmer);
                if (programmer.WorkItem.Component != Component.None) remainingWork--;
            }
        }
    }
}