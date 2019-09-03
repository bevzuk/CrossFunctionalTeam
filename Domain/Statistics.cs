namespace Domain
{
    public class Statistics
    {
        public Statistics(double throughputRate, double leadTime)
        {
            ThroughputRate = throughputRate;
            LeadTime = leadTime;
        }

        public double ThroughputRate { get; }
        public double LeadTime { get; }

        #region Equality members

        private bool Equals(Statistics other)
        {
            return ThroughputRate.Equals(other.ThroughputRate) && LeadTime.Equals(other.LeadTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Statistics) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ThroughputRate.GetHashCode() * 397) ^ LeadTime.GetHashCode();
            }
        }

        public static bool operator ==(Statistics left, Statistics right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Statistics left, Statistics right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}