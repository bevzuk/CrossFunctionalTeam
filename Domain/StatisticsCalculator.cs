using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class StatisticsCalculator
    {
        public Statistics Calculate(IList<ScheduleData> scheduleData)
        {
            var days = scheduleData.Select(_ => _.Day).Distinct();
            var backlogItems = scheduleData.Select(_ => _.BacklogItem).Distinct();
            var statistics = backlogItems
                .Select(_ => scheduleData.Where(d => d.BacklogItem == _))
                .Select(_ => new Statistics(1m / _.Count(), _.Count()));
            return new Statistics(
                (decimal) backlogItems.Count() / days.Count(),
                statistics.Average(_ => _.LeadTime));
        }
    }
}