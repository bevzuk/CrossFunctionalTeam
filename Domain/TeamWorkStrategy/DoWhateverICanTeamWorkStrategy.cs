namespace Domain.TeamWorkStrategy
{
    public class DoWhateverICanTeamWorkStrategy : RespectBacklogOrderTeamStrategy, ITeamWorkStrategy
    {
        public void DistributeWork(Backlog backlog, Team team)
        {
            foreach (var programmer in team.Members) ChooseWork(backlog, programmer);
        }
    }
}