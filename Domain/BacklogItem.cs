using System.Linq;

namespace Domain
{
    public class BacklogItem
    {
        public readonly string Name;
        private readonly Component[] _components;

        public BacklogItem(string name, params Component[] components)
        {
            Name = name;
            _components = components;
        }

        public string Components => _components.Select(_ => _.Name).Aggregate(string.Empty, string.Concat);

        #region Equality members

        protected bool Equals(BacklogItem other)
        {
            return Name == other.Name && Equals(_components, other._components);
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
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (_components != null ? _components.GetHashCode() : 0);
            }
        }

        #endregion
    }
}