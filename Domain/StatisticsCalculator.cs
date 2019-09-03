using System.Collections.Generic;

namespace Domain
{
    public class StatisticsCalculator
    {
        public Statistics Calculate(IEnumerable<ScheduleData> scheduleData)
        {
            return new Statistics(1, 1);
        }
    }
}