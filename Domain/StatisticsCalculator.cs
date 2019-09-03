using System.Collections.Generic;

namespace Domain
{
    public class StatisticsCalculator
    {
        public Statistics Calculate(IList<ScheduleData> scheduleData)
        {
            return new Statistics(1f / scheduleData.Count, scheduleData.Count);
        }
    }
}