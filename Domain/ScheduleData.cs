namespace Domain
{
    public class ScheduleData
    {
        public ScheduleData(int day, string backlogItem, string component)
        {
            Day = day;
            BacklogItem = backlogItem;
            Component = component;
        }

        public int Day { get; }
        public string BacklogItem { get; }
        public string Component { get; }
    }
}