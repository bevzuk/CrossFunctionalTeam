using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Domain {
    public class BacklogItems {
        private readonly List<BacklogItem> items = new List<BacklogItem>();

        public ReadOnlyCollection<BacklogItem> Items => items.AsReadOnly();

        public ReadOnlyCollection<BacklogItem> ItemsStartedFirst =>
            items.OrderBy(_ => _.IsStarted ? 0 : 1).ToList().AsReadOnly();

        public bool HasItemsToDo => items.Any(pbi => pbi.HasComponentToDo);

        public void Add(BacklogItem backlogItem) {
            items.Add(backlogItem);
        }
    }
}