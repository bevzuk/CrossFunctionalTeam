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

        public void WorkOn(BacklogItem backlogItem, Component component)
        {
            WorkItem = new WorkItem(backlogItem, component);
            component.Take();
        }

        public void DoNothing()
        {
            WorkOn(BacklogItem.None, Component.None);
        }
    }
}