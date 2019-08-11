using System.Collections.Generic;

namespace Domain
{
    public class Team
    {
        private readonly List<Programmer> members = new List<Programmer>();
        
        public void Add(Programmer programmer)
        {
            members.Add(programmer);
        }

        public IReadOnlyCollection<Programmer> Members => members.AsReadOnly();
    }
}