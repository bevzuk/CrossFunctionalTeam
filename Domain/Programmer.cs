using System.Linq;

namespace Domain
{
    public class Programmer
    {
        public string Name { get; }

        public Skill Skill { get; private set; }

        public Component WorkingOn { get; private set; }

        public Programmer(string name = "")
        {
            Name = name;
        }

        public void Learn(Skill skill)
        {
            Skill = skill;
        }

        public void ChooseWorkFrom(BacklogItem backlogItem)
        {
            var appropriateComponent = backlogItem.FindComponentFor(Skill);
            if (appropriateComponent != null)
            {
                WorkOn(appropriateComponent);
            }
            else
            {
                DoNothing();
            }
        }

        public void ChooseWorkFrom(Backlog backlog)
        {
            foreach (var backlogItem in backlog.Items)
            {
                ChooseWorkFrom(backlogItem);
                if (!Equals(WorkingOn, Component.None)) return;
            }
        }

        private void WorkOn(Component component)
        {
            WorkingOn = component;
            component.Take();
        }

        private void DoNothing()
        {
            WorkOn(Component.None);
        }
    }
}