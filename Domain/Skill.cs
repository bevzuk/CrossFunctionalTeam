namespace Domain {
    public class Skill {
        public string Name { get; }

        public Skill(string name) {
            Name = name;
        }

        #region Equality members

        protected bool Equals(Skill other) {
            return Name == other.Name;
        }

        public override bool Equals(object? obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Name == ((Skill)obj).Name;
        }

        public override int GetHashCode() {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        #endregion
    }
}