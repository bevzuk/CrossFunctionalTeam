namespace Domain.TeamWorkStrategy
{
    public abstract class RespectBacklogOrderTeamStrategy
    {
        protected void ChooseWork(Backlog backlog, Programmer programmer)
        {
            foreach (var backlogItem in backlog.Items)
            {
                if (programmer.HasSkillsFor(backlogItem))
                {
                    Work(programmer, backlogItem);
                    return;
                }

                programmer.DoNothing();
            }
        }

        private void Work(Programmer programmer, BacklogItem backlogItem)
        {
            var componentToWork = backlogItem.FindComponentFor(programmer.Skills);
            programmer.WorkOn(backlogItem, componentToWork);
        }
    }
}