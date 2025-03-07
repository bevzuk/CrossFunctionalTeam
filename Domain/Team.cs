using Domain.TeamWorkStrategy;

namespace Domain {
    public class Team {
        private readonly List<Programmer> members = new List<Programmer>();
        private readonly ITeamWorkStrategy teamWorkStrategy;

        public Team(ITeamWorkStrategy teamWorkStrategy) {
            this.teamWorkStrategy = teamWorkStrategy;
        }

        public IReadOnlyCollection<Programmer> Members => members.AsReadOnly();

        public void Add(params Programmer[] programmers) {
            members.AddRange(programmers);
        }

        public void DistributeWork(Backlog backlog) {
            teamWorkStrategy.DistributeWork(backlog, this);
        }

        public void DoNothing() {
            members.ForEach(_ => _.DoNothing());
        }

        public int Wip {
            get {
                return Members
                   .Where(_ => _.IsWorking)
                   .Select(_ => _.WorkItem.BacklogItem.Name)
                   .Distinct()
                   .Count();
            }
        }
    }
}