using System.Collections.ObjectModel;
using System.Linq;

namespace Domain {
    public class RemainingBacklog {
        public RemainingBacklog(Backlog backlog) {
            Items = backlog.Items.Where(_ => _.Status != BacklogItemStatus.Finished).ToList().AsReadOnly();
        }

        public ReadOnlyCollection<BacklogItem> Items { get; }
    }
}