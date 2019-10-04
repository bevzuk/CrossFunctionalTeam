using System.Collections.Generic;
using System.Linq;

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

        public void FinishStartedWork() {
            foreach (var backlogItem in Items.Where(_ => _.Status == BacklogItemStatus.Started)) {
                if (!backlogItem.HasComponentToDo) backlogItem.Complete();
            }
        }
    }
}