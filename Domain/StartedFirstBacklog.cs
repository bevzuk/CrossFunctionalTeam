using System.Collections.ObjectModel;

namespace Domain {
    public class StartedFirstBacklog {
        public StartedFirstBacklog(Backlog backlog) {
            Items = backlog.Items.OrderBy(_ => _.Status == BacklogItemStatus.Started ? 0 : 1).ToList().AsReadOnly();
        }

        public ReadOnlyCollection<BacklogItem> Items { get; }
    }
}