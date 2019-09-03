namespace Domain.Test.DSL
{
    public class WorkItemBuilder
    {
        private BacklogItem backlogItem = new BacklogItem(string.Empty, Component.None);
        private Component component = Component.None;

        public WorkItemBuilder WithBacklogItem(string name, string componentName)
        {
            backlogItem = new BacklogItem(name, new Component(componentName));
            return this;
        }

        public WorkItemBuilder WithComponent(string name)
        {
            component = new Component(name);
            return this;
        }

        public static implicit operator WorkItem(WorkItemBuilder builder)
        {
            return new WorkItem(builder.backlogItem, builder.component);
        }
    }
}