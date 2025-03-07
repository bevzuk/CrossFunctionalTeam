namespace Domain {
    public class WorkItem {
        public static WorkItem None { get; } = new WorkItem(BacklogItem.None, Component.None);

        public WorkItem(BacklogItem backlogItem, Component? component = null) {
            BacklogItem = backlogItem;
            Component = component ?? Component.None;
        }

        public BacklogItem BacklogItem { get; }
        public Component Component { get; }

        public override string ToString() {
            return $"{BacklogItem.Name}.{Component.Name}";
        }

        #region Equality members

        private bool Equals(WorkItem other) {
            return BacklogItem.Equals(other.BacklogItem) && Component.Equals(other.Component);
        }

        public override bool Equals(object? obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            var other = (WorkItem)obj;
            return BacklogItem.Equals(other.BacklogItem) && Component.Equals(other.Component);
        }

        public override int GetHashCode() {
            unchecked {
                var backlogHash = BacklogItem.GetHashCode();
                var componentHash = Component.GetHashCode();
                return (backlogHash * 397) ^ componentHash;
            }
        }

        public static bool operator ==(WorkItem? left, WorkItem? right) {
            if (ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(left, null)) return false;
            if (ReferenceEquals(right, null)) return false;
            return left.Equals(right);
        }

        public static bool operator !=(WorkItem? left, WorkItem? right) {
            return !(left == right);
        }

        #endregion
    }
}