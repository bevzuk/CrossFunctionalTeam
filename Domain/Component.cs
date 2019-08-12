using System;

namespace Domain
{
    public class Component
    {
        public string Name { get; }
        public bool IsTaken { get; private set; }

        public Component(string name)
        {
            Name = name;
        }

        public void Take()
        {
            IsTaken = true;
        }

        public static Component None => new Component(string.Empty);

        public override string ToString()
        {
            return Name;
        }

        #region Equality members

        protected bool Equals(Component other)
        {
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Component) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
        
        public static bool operator == (Component a, Component b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (Equals(a, null)) return false;
            if (Equals(b, null)) return false;
            
            return a.Equals(b);
        }

        public static bool operator !=(Component a, Component b)
        {
            return !(a == b);
        }

        #endregion
    }
}