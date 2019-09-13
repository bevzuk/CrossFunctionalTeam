using System.Linq;

namespace Domain.TeamWorkStrategy
{
    public class RespectWipLimitIgnoreBacklogOrderTeamWorkStrategy : IgnoreBacklogOrderTeamWorkStrategy
    {
        private readonly int wipLimit;

        public RespectWipLimitIgnoreBacklogOrderTeamWorkStrategy(int wipLimit)
        {
            this.wipLimit = wipLimit;
        }

        public override void DistributeWork(Backlog backlog, Team team)
        {
            foreach (var programmer in team.Members) programmer.DoNothing();

            if (wipLimit <= Wip(team)) return;

            foreach (var programmer in team.Members)
            {
                ChooseWork(backlog, programmer);
                if (wipLimit <= Wip(team)) return;
            }
        }

        private int Wip(Team team)
        {
            return team.Members
                .Where(_ => _.IsWorking)
                .Select(_ => _.WorkItem.BacklogItem.Name)
                .Distinct()
                .Count();
        }
    }
}