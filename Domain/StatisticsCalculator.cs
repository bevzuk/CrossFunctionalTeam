using System.Collections.Generic;
using System.Linq;

namespace Domain {
    public class StatisticsCalculator {
        public Statistics Calculate(IEnumerable<ScheduleData> scheduleData) {
            var valuableScheduleData = scheduleData.Where(_ => _.Component != Component.None.Name);

            var days = valuableScheduleData.Select(_ => _.Day).Distinct();
            var backlogItems = valuableScheduleData.Select(_ => _.BacklogItem).Distinct();
            var leadTimes = backlogItems
               .Select(_ => valuableScheduleData.Where(d => d.BacklogItem == _))
               .Select(_ => _.Max(w => w.Day) - _.Min(w => w.Day) + 1);
            return new Statistics(
                                  (decimal) backlogItems.Count() / (days.Max() - days.Min() + 1),
                                  (decimal) leadTimes.Average(_ => _));
        }
    }
}