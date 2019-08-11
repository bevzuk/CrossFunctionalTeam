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
            component.Process();
        }

        public void ChooseWorkFrom(BacklogItem backlogItem)
        {
            var components = backlogItem.Components;
            var appropriateComponent = components.FirstOrDefault(_ => _.Name == Skill.Name && !_.isProcessing);
            if (appropriateComponent == null)
            {
                WorkOn(Component.None);
            }
            else
            {
                WorkOn(appropriateComponent);
            }
        }
    }
}