namespace Domain.TeamWorkStrategy
{
    public interface ITeamWorkStrategy
    {
        void ChooseWork(Backlog backlog, Programmer programmer);
    }
}