using System.Linq;

namespace Domain.TeamWorkStrategy {
    public class RespectWipLimitIgnoreBacklogOrderTeamWorkStrategy : IgnoreBacklogOrderTeamWorkStrategy {
        private readonly int wipLimit;

        public RespectWipLimitIgnoreBacklogOrderTeamWorkStrategy(int wipLimit) {
            this.wipLimit = wipLimit;
        }

        public override void DistributeWork(Backlog backlog, Team team) {
            team.DoNothing();

            foreach (var backlogItem in backlog.Items) {
                DistributeWork(backlogItem, team);
                if (wipLimit <= Wip(team)) return;
            }
        }

        private void DistributeWork(BacklogItem backlogItem, Team team) {
            foreach (var programmer in team.Members) {
                if (!programmer.IsWorking && programmer.HasSkillsFor(backlogItem)) {
                    Work(programmer, backlogItem);
                }
            }
        }

        private int Wip(Team team) {
            return team.Members
               .Where(_ => _.IsWorking)
               .Select(_ => _.WorkItem.BacklogItem.Name)
               .Distinct()
               .Count();
        }
    }
}