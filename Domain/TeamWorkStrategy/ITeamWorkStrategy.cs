namespace Domain.TeamWorkStrategy {
    public interface ITeamWorkStrategy {
        void DistributeWork(Backlog backlog, Team team);
    }
}