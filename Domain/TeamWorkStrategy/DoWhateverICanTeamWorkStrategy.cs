namespace Domain.TeamWorkStrategy
{
    public class DoWhateverICanTeamWorkStrategy : ITeamWorkStrategy
    {
        public void ChooseWork(Backlog backlog, Programmer programmer)
        {
            foreach (var backlogItem in backlog.Items)
            foreach (var skill in programmer.Skills)
            {
                var componentToWork = backlogItem.FindComponentFor(skill);
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