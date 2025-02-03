namespace Domain {
    public class Component {
        public Component(string name) {
            Name = name;
        }

        public string Name { get; }
        public bool IsStarted { get; private set; }

        public static Component None => new Component(string.Empty);

        public void StartWorkingOn() {
            IsStarted = true;
        }

        public override string ToString() {
            return Name;
        }

        #region Equality members

        private bool Equals(Component other) {
            return Name == other.Name;
        }

        public override bool Equals(object? obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Name == ((Component)obj).Name;
        }

        public override int GetHashCode() {
            return Name != null ? Name.GetHashCode() : 0;
        }

        public static bool operator ==(Component a, Component b) {
            if (ReferenceEquals(a, b)) return true;
            if (Equals(a, null)) return false;
            if (Equals(b, null)) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Component a, Component b) {
            return !(a == b);
        }

        #endregion
    }
}