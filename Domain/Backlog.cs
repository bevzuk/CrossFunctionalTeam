namespace Domain {
    public class Backlog {
        private readonly BacklogItems backlogItems;

        public Backlog() {
            backlogItems = new BacklogItems();
            Items = backlogItems.Items;
        }

        public IEnumerable<BacklogItem> Items { get; }
        public bool HasItemsToDo => backlogItems.HasItemsToDo;

        public void Add(BacklogItem backlogItem) {
            backlogItems.Add(backlogItem);
        }

        public void FinishStartedWork() {
            foreach (var backlogItem in Items.Where(_ => _.Status == BacklogItemStatus.Started)) {
                backlogItem.Complete();
            }
        }
    }
}