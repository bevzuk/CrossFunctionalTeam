using System.Linq;

namespace Domain.Test.DSL {
    public class WorkItemBuilder {
        private BacklogItem backlogItem = new BacklogItem(string.Empty, Component.None);
        private Component component = Component.None;

        public WorkItem Please => this;

        public WorkItemBuilder ForBacklogItem(string name, params string[] componentNames) {
            backlogItem = new BacklogItem(name, componentNames.Select(_ => new Component(_)).ToArray());
            return this;
        }

        public WorkItemBuilder WorkOnComponent(string name) {
            component = new Component(name);
            return this;
        }

        public WorkItemBuilder NoWork() {
            component = Component.None;
            return this;
        }

        public static implicit operator WorkItem(WorkItemBuilder builder) {
            return new WorkItem(builder.backlogItem, builder.component);
        }
    }
}