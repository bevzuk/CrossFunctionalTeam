using System.Linq;

namespace Domain
{
    public class Programmer
    {
        public string Name { get; }

        public Skill Skill { get; private set; }

        public BacklogItem WorkingOnBacklogItem { get; private set; }
        public Component WorkingOnComponent { get; private set; }

        public Programmer(string name = "")
        {
            Name = name;
        }

        public void Learn(Skill skill)
        {
            Skill = skill;
        }

        public void ChooseWorkFrom(Backlog backlog)
        {
            foreach (var backlogItem in backlog.Items)
            {
                ChooseWorkFrom(backlogItem);
                if (!Equals(WorkingOnComponent, Component.None)) return;
            }
        }

        public void ChooseWorkFrom(BacklogItem backlogItem)
        {
            var appropriateComponent = backlogItem.FindComponentFor(Skill);
            if (appropriateComponent != null)
            {
                WorkOn(backlogItem, appropriateComponent);
            }
            else
            {
                DoNothing();
            }
        }

        private void WorkOn(BacklogItem backlogItem, Component component)
        {
            WorkingOnBacklogItem = backlogItem;
            WorkingOnComponent = component;
            component.Take();
        }

        private void DoNothing()
        {
            WorkOn(BacklogItem.None, Component.None);
        }
    }
}