using System.Collections.Generic;
using System.Linq;

namespace Domain {
    public class Programmer {
        public Programmer(string name = "") {
            Name = name;
            Skills = new List<Skill>();
        }

        public string Name { get; }
        public List<Skill> Skills { get; }
        public WorkItem WorkItem { get; private set; }
        public bool IsWorking => WorkItem.Component != Component.None;

        public void Learn(Skill skill) {
            Skills.Add(skill);
        }

        public void WorkOn(BacklogItem backlogItem, Component component) {
            WorkItem = new WorkItem(backlogItem, component);
            component.Take();
        }

        public void DoNothing() {
            WorkOn(BacklogItem.None, Component.None);
        }

        public bool HasSkillsFor(BacklogItem backlogItem) {
            return Skills
               .Select(backlogItem.FindComponentFor)
               .Any(componentToWork => componentToWork != Component.None);
        }
    }
}