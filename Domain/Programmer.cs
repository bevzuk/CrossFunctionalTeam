using System.Linq;

namespace Domain
{
    public class Programmer
    {
        public void Learn(Skill skill)
        {
            Skill = skill;
        }

        public Skill Skill { get; private set; }
        public Component WorkingOn { get; private set; }

        private void WorkOn(Component component)
        {
            WorkingOn = component;
            component.Take();
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

        private void DoNothing()
        {
            WorkOn(Component.None);
        }
    }
}