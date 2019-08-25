namespace Domain
{
    public class Statistics
    {
        public double ThroughputRate { get; private set; }

        public void Update()
        {
            ThroughputRate++;
        }
    }
}