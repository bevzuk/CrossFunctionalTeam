namespace Domain {
    public class ScheduleData {
        public ScheduleData(int day, WorkItem workItem) {
            Day = day;
            BacklogItem = workItem.BacklogItem.Name;
            Component = workItem.Component.Name;
        }

        public int Day { get; }
        public string BacklogItem { get; }
        public string Component { get; }
    }
}