namespace Domain {
    public class Components {
        private readonly List<Component> components;

        public Components(IEnumerable<Component> components) {
            this.components = new List<Component>(components);
        }

        public bool HasComponentToDo => components.Any(c => !c.IsStarted);

        public Component FindComponentFor(Skill skill) {
            return components.FirstOrDefault(_ => _.Name == skill.Name && !_.IsStarted) ?? Component.None;
        }

        private bool Equals(Components other) {
            if (components.Count != other.components.Count) return false;
            for (var i = 0; i < components.Count; i++)
                if (!components[i].Equals(other.components[i]))
                    return false;
            return true;
        }

        public override bool Equals(object? obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Components)obj);
        }

        public override int GetHashCode() {
            if (components == null) return 0;
            
            unchecked {
                return components.Aggregate(17, (current, component) => 
                    current * 23 + (component?.GetHashCode() ?? 0));
            }
        }
    }
}