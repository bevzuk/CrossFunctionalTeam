using System.Collections.Generic;

namespace Domain
{
    public class Backlog
    {
        public IList<BacklogItem> Items { get; }
    
        public Backlog()
        {
            Items = new List<BacklogItem>();
        }

        public void Add(BacklogItem backlogItem)
        {    
            Items.Add(backlogItem);
        }
    }
}