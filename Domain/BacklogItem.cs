using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class BacklogItem
    {
        public readonly string Name;
        private readonly List<Component> components;

        public BacklogItem(string name, params Component[] components)
        {
            Name = name;
            this.components = new List<Component>(components);
        }

        public IReadOnlyCollection<Component> Components => components.AsReadOnly();

        #region Equality members

        protected bool Equals(BacklogItem other)
        {
            var collectionsAreEqual = true;
            if (components.Count != other.components.Count) return false;
            for (var i = 0; i < components.Count; i++)
            {
                if (!components[i].Equals(other.components[i])) collectionsAreEqual = false;
            }
            
            return Name == other.Name && collectionsAreEqual;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BacklogItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (components != null ? components.GetHashCode() : 0);
            }
        }

        #endregion
    }
}