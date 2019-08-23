namespace Domain
{
    public class ScheduleData
    {
        public string BacklogItem { get; }
        public string Component { get; }

        public ScheduleData(string backlogItem, string component)
        {
            BacklogItem = backlogItem;
            Component = component;
        }
    }
}