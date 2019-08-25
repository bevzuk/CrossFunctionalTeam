using System.Collections.Generic;

namespace Domain
{
    public class Team
    {
        private readonly List<Programmer> members = new List<Programmer>();
        public readonly Statistics Statistics = new Statistics();

        public IReadOnlyCollection<Programmer> Members => members.AsReadOnly();

        public void Add(params Programmer[] programmers)
        {
            members.AddRange(programmers);
        }

        public void WorkOn(Backlog backlog)
        {
            foreach (var _ in backlog.Items) Statistics.Update();
        }

        public void DistributeWork(Backlog backlog)
        {
            foreach (var programmer in Members) programmer.ChooseWorkFrom(backlog);
        }
    }
}