using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Components
    {
        private readonly List<Component> components;

        public Components(IEnumerable<Component> components)
        {
            this.components = new List<Component>(components);
        }

        public bool HasComponentToDo => components.Any(c => !c.IsTaken);

        public Component FindComponentFor(Skill skill)
        {
            return components.FirstOrDefault(_ => _.Name == skill.Name && !_.IsTaken) ?? Component.None;
        }

        private bool Equals(Components other)
        {
            var collectionsAreEqual = true;
            if (components.Count != other.components.Count) return false;
            for (var i = 0; i < components.Count; i++)
                if (!components[i].Equals(other.components[i]))
                    return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Components) obj);
        }

        public override int GetHashCode()
        {
            return components != null ? components.GetHashCode() : 0;
        }
    }
}