using System.Collections.Generic;

namespace Domain {
    public class BacklogItem {
        private readonly Components components;
        public readonly string Name;
        public BacklogItemStatus Status { get; private set; } = BacklogItemStatus.NotStarted;


        public BacklogItem(string name, params Component[] components) {
            Name = name;
            this.components = new Components(components);
        }

        public bool HasComponentToDo => components.HasComponentToDo;

        public static BacklogItem None => new BacklogItem(string.Empty);

        public Component FindComponentFor(IEnumerable<Skill> skills) {
            foreach (var skill in skills) {
                var component = FindComponentFor(skill);
                if (component != Component.None) return component;
            }

            return Component.None;
        }

        public Component FindComponentFor(Skill skill) {
            return components.FindComponentFor(skill);
        }

        public void StartWorkingOn(Component componentToWork) {
            Status = BacklogItemStatus.Started;
            componentToWork.StartWorkingOn();
        }

        public void Complete() {
            if (!HasComponentToDo) Status = BacklogItemStatus.Finished;
        }

        #region Equality members

        private bool Equals(BacklogItem other) {
            return Name == other.Name && components.Equals(other.components);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((BacklogItem) obj);
        }

        public override int GetHashCode() {
            unchecked {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^
                       (components != null ? components.GetHashCode() : 0);
            }
        }

        #endregion
    }
}