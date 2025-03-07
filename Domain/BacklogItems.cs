using System.Collections.ObjectModel;

namespace Domain {
    public class BacklogItems {
        private readonly List<BacklogItem> items = new List<BacklogItem>();

        public ReadOnlyCollection<BacklogItem> Items => items.AsReadOnly();

        public bool HasItemsToDo => items.Any(pbi => pbi.HasComponentToDo);

        public void Add(BacklogItem backlogItem) {
            items.Add(backlogItem);
        }
    }
}