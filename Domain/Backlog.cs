using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Backlog
    {
        public Backlog()
        {
            Items = new List<BacklogItem>();
        }

        public IList<BacklogItem> Items { get; }
        public bool HasItemsToDo => Items.Any(pbi => !pbi.Components.ToList().TrueForAll(c => c.IsTaken));

        public void Add(BacklogItem backlogItem)
        {
            Items.Add(backlogItem);
        }
    }
}