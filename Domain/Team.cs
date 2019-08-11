using System.Collections.Generic;
using System.Linq;

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
        public readonly Statistics Statistics = new Statistics();

        public void WorkOn(Backlog backlog)
        {
            foreach (var backlogItem in backlog.Items)
            {
                Statistics.Update();
            }
        }

        public void DistributeWork(Backlog backlog)
        {
            var backlogItem = backlog.Items.First();
            foreach (var programmer in Members)
            {
                var components = backlogItem.Components;
                var appropriateComponent = components.FirstOrDefault(_ => _.Name == programmer.Skill.Name);
                if (appropriateComponent != null)
                {
                    programmer.WorkOn(appropriateComponent);
                }
            }
        }
    }
}