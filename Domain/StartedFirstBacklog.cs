using System.Collections.Generic;

namespace Domain {
    public class StartedFirstBacklog {
        public IReadOnlyCollection<BacklogItem> Items { get; }

        public StartedFirstBacklog(Backlog backlog) {
            Items = new StartedFirstBacklogItems(backlog.Items).Items;
        }
    }
}