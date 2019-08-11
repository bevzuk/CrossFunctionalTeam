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

        public void WorkOn(Component component)
        {
            WorkingOn = component;
        }

        public void ChooseWorkFrom(BacklogItem backlogItem)
        {
            var components = backlogItem.Components;
            var appropriateComponent = components.FirstOrDefault(_ => _.Name == Skill.Name);

            if (appropriateComponent != null) WorkOn(appropriateComponent);
        }
    }
}