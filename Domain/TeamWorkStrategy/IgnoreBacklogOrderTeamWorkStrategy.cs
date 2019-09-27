namespace Domain.TeamWorkStrategy {
    public class IgnoreBacklogOrderTeamWorkStrategy : ITeamWorkStrategy {
        public virtual void DistributeWork(Backlog backlog, Team team) {
            foreach (var programmer in team.Members) ChooseWork(backlog, programmer);
        }

        private void ChooseWork(Backlog backlog, Programmer programmer) {
            foreach (var backlogItem in backlog.Items) {
                if (programmer.HasSkillsFor(backlogItem)) {
                    Work(programmer, backlogItem);
                    return;
                }
            }

            programmer.DoNothing();
        }

        protected void Work(Programmer programmer, BacklogItem backlogItem) {
            var componentToWork = backlogItem.FindComponentFor(programmer.Skills);
            programmer.WorkOn(backlogItem, componentToWork);
            backlogItem.Start();
        }
    }
}