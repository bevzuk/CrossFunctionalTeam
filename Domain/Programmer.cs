namespace Domain
{
    public class Programmer
    {
        public Programmer(string name = "")
        {
            Name = name;
        }

        public string Name { get; }

        public Skill Skill { get; private set; }

        public WorkItem WorkItem { get; private set; }

        public void Learn(Skill skill)
        {
            Skill = skill;
        }

        public void ChooseWorkFrom(Backlog backlog)
        {
            foreach (var backlogItem in backlog.Items)
            {
                ChooseWorkFrom(backlogItem);
                if (!Equals(WorkItem.Component, Component.None)) return;
            }
        }

        public void ChooseWorkFrom(BacklogItem backlogItem)
        {
            var appropriateComponent = backlogItem.FindComponentFor(Skill);
            if (appropriateComponent != null)
                WorkOn(backlogItem, appropriateComponent);
            else
                DoNothing();
        }

        private void WorkOn(BacklogItem backlogItem, Component component)
        {
            WorkItem = new WorkItem(backlogItem, component);
            component.Take();
        }

        private void DoNothing()
        {
            WorkOn(BacklogItem.None, Component.None);
        }
    }
}