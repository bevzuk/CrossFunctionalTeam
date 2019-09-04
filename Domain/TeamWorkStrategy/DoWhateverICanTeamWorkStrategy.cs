namespace Domain.TeamWorkStrategy
{
    public class DoWhateverICanTeamWorkStrategy : ITeamWorkStrategy
    {
        public void ChooseWork(Backlog backlog, Programmer programmer)
        {
            foreach (var backlogItem in backlog.Items)
            {
                var componentToWork = backlogItem.FindComponentFor(programmer.Skill);
                if (componentToWork != Component.None)
                {
                    programmer.WorkOn(backlogItem, componentToWork);
                    return;
                }
            }

            programmer.DoNothing();
        }
    }
}