using System.Collections.Generic;
using Domain.TeamWorkStrategy;

namespace Domain
{
    public class Team
    {
        private readonly List<Programmer> members = new List<Programmer>();
        private readonly ITeamWorkStrategy teamWorkStrategy;

        public Team(ITeamWorkStrategy teamWorkStrategy)
        {
            this.teamWorkStrategy = teamWorkStrategy;
        }

        public IReadOnlyCollection<Programmer> Members => members.AsReadOnly();

        public void Add(params Programmer[] programmers)
        {
            members.AddRange(programmers);
        }

        public void DistributeWork(Backlog backlog)
        {
            foreach (var programmer in Members) teamWorkStrategy.ChooseWork(backlog, programmer);
        }
    }
}