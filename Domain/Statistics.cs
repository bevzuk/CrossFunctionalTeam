namespace Domain
{
    public class Statistics
    {
        public double LeadTime { get; }
        public double ThroughputRate { get; private set; }

        public void Update()
        {
            ThroughputRate++;
        }
    }
}