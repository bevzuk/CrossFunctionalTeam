namespace Domain.TeamWorkStrategy {
    public class RespectWipLimitIgnoreBacklogOrderTeamWorkStrategy : ITeamWorkStrategy {
        private readonly int wipLimit;

        public RespectWipLimitIgnoreBacklogOrderTeamWorkStrategy(int wipLimit) {
            this.wipLimit = wipLimit;
        }

        public void DistributeWork(Backlog backlog, Team team) {
            team.DoNothing();

            foreach (var backlogItem in new StartedFirstBacklog(backlog).Items) {
                DistributeWork(backlogItem, team);
                if (wipLimit <= team.Wip) return;
            }
        }

        private void DistributeWork(BacklogItem backlogItem, Team team) {
            foreach (var programmer in team.Members) {
                DistributeWork(backlogItem, programmer);
            }
        }

        private void DistributeWork(BacklogItem backlogItem, Programmer programmer) {
            if (!programmer.IsWorking && programmer.HasSkillsFor(backlogItem)) {
                programmer.WorkOn(backlogItem);
            }
        }
    }
}