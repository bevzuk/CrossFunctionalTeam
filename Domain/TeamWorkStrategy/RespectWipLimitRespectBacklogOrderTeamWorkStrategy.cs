using System.Linq;

namespace Domain.TeamWorkStrategy {
    public class RespectWipLimitRespectBacklogOrderTeamWorkStrategy : ITeamWorkStrategy {
        private readonly int wipLimit;

        public RespectWipLimitRespectBacklogOrderTeamWorkStrategy(int wipLimit) {
            this.wipLimit = wipLimit;
        }

        public void DistributeWork(Backlog backlog, Team team) {
            team.DoNothing();
            backlog.FinishStartedWork();

            foreach (var backlogItem in new RemainingBacklog(backlog).Items.Take(wipLimit)) {
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