namespace Domain
{
    public class WorkItem
    {
        public WorkItem(BacklogItem backlogItem, Component component)
        {
            BacklogItem = backlogItem;
            Component = component;
        }

        public BacklogItem BacklogItem { get; }
        public Component Component { get; }
    }
}