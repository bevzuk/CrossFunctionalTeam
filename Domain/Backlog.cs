using System.Collections.Generic;

namespace Domain {
    public class Backlog {
        private readonly BacklogItems backlogItems;

        public Backlog() {
            backlogItems = new BacklogItems();
        }

        public IEnumerable<BacklogItem> Items => backlogItems.Items;
        public bool HasItemsToDo => backlogItems.HasItemsToDo;

        public void Add(BacklogItem backlogItem) {
            backlogItems.Add(backlogItem);
        }
    }
}