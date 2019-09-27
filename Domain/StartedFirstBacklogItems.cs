using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Domain {
    public class StartedFirstBacklogItems {
        private readonly List<BacklogItem> items;

        public ReadOnlyCollection<BacklogItem> Items => items.AsReadOnly();

        public StartedFirstBacklogItems(IEnumerable<BacklogItem> backlogItems) {
            items = backlogItems.OrderBy(_ => _.IsStarted ? 0 : 1).ToList();
        }
    }
}