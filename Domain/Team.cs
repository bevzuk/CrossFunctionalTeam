using System.Collections.Generic;

namespace Domain
{
    public class Team
    {
        private readonly List<Programmer> members = new List<Programmer>();
        
        public void Add(params Programmer[] programmers)
        {
            members.AddRange(programmers);
        }

        public IReadOnlyCollection<Programmer> Members => members.AsReadOnly();
        public Statistics Statistics => new Statistics();
    }
}