namespace Domain {
    public class Programmer(string name)
    {
        public string Name { get; } = name;
        public List<Skill> Skills { get; } = [];
        public WorkItem WorkItem { get; private set; } = new WorkItem(new BacklogItem(""), Component.None);
        public bool IsWorking => WorkItem.Component != Component.None;

        public void Learn(Skill skill) {
            Skills.Add(skill);
        }

        public void WorkOn(BacklogItem backlogItem) {
            var componentToWork = backlogItem.FindComponentFor(Skills);
            backlogItem.StartWorkingOn(componentToWork);
            WorkItem = new WorkItem(backlogItem, componentToWork);
        }

        public void DoNothing() {
            WorkOn(BacklogItem.None);
        }

        public bool HasSkillsFor(BacklogItem backlogItem) {
            return Skills
               .Select(backlogItem.FindComponentFor)
               .Any(componentToWork => componentToWork != Component.None);
        }
    }
}