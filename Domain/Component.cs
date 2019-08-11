namespace Domain
{
    public class Component
    {
        public bool isProcessing { get; private set; }
        public string Name { get; }
        public static Component None => new Component(string.Empty);

        public Component(string name)
        {
            Name = name;
        }

        public void Process()
        {
            isProcessing = true;
        }

        public override string ToString()
        {
            return Name;
        }

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
    }
}