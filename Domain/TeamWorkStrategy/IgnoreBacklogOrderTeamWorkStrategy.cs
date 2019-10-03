namespace Domain.TeamWorkStrategy {
    public sealed class IgnoreBacklogOrderTeamWorkStrategy : ITeamWorkStrategy {
        public void DistributeWork(Backlog backlog, Team team) {
            foreach (var programmer in team.Members) {
                ChooseWork(backlog, programmer);
            }
        }

        private void ChooseWork(Backlog backlog, Programmer programmer) {
            foreach (var backlogItem in backlog.Items) {
                if (programmer.HasSkillsFor(backlogItem)) {
                    programmer.WorkOn(backlogItem);
                    return;
                }
            }

            programmer.DoNothing();
        }
    }
}