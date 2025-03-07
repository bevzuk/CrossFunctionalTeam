namespace Domain {
    public class StatisticsCalculator {
        public Statistics Calculate(IEnumerable<ScheduleData> scheduleData) {
            if (!scheduleData.Any())
                throw new ArgumentException("Schedule cannot be empty", nameof(scheduleData));

            var valuableScheduleData = scheduleData.Where(_ => _.Component != Component.None.Name);
            if (!valuableScheduleData.Any())
                return new Statistics(0, 0);

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