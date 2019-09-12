namespace Domain.TeamWorkStrategy
{
    public class RespectWipLimitIgnoreBacklogOrderTeamWorkStrategy : IgnoreBacklogOrderTeamWorkStrategy
    {
        private readonly int wipLimit;

        public RespectWipLimitIgnoreBacklogOrderTeamWorkStrategy(int wipLimit)
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
                if (programmer.IsWorking) remainingWork--;
            }
        }
    }
}