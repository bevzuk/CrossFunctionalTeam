using Domain;

namespace Tests.DSL
{
    public class ProgrammerBuilder
    {
        private string name = string.Empty;

        public Programmer WithSkill(string skillName)   
        {
            var programmer = new Programmer(name);
            programmer.Learn(new Skill(skillName));
            return programmer;
        }

        public ProgrammerBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }
    }
}