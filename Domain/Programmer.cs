namespace Domain {
    public class Programmer(string name)
    {
        private readonly List<Skill> skills = [];
        
        public string Name { get; } = name;
        public IReadOnlyList<Skill> Skills => skills;
        public WorkItem WorkItem { get; private set; } = WorkItem.None;
        public bool IsWorking => WorkItem.Component != Component.None;

        public void Learn(Skill skill) {
            skills.Add(skill);
        }

        public void WorkOn(BacklogItem backlogItem) {
            var componentToWork = backlogItem.FindComponentFor(skills);
            backlogItem.StartWorkingOn(componentToWork);
            WorkItem = new WorkItem(backlogItem, componentToWork);
        }

        public void DoNothing() {
            WorkItem = WorkItem.None;
        }

        public bool HasSkillsFor(BacklogItem backlogItem) {
            return skills
               .Select(backlogItem.FindComponentFor)
               .Any(componentToWork => componentToWork != Component.None);
        }
    }
}