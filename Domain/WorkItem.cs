namespace Domain {
    public class WorkItem {
        public WorkItem(BacklogItem backlogItem, Component component) {
            BacklogItem = backlogItem;
            Component = component;
        }

        public BacklogItem BacklogItem { get; }
        public Component Component { get; }

        public override string ToString() {
            return $"{BacklogItem.Name}.{Component.Name}";
        }

        #region Equality members

        private bool Equals(WorkItem other) {
            return Equals(BacklogItem, other.BacklogItem) && Equals(Component, other.Component);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((WorkItem) obj);
        }

        public override int GetHashCode() {
            unchecked {
                return ((BacklogItem != null ? BacklogItem.GetHashCode() : 0) * 397) ^
                       (Component != null ? Component.GetHashCode() : 0);
            }
        }

        public static bool operator ==(WorkItem left, WorkItem right) {
            return Equals(left, right);
        }

        public static bool operator !=(WorkItem left, WorkItem right) {
            return !Equals(left, right);
        }

        #endregion
    }
}