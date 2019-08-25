namespace Domain.Test.DSL
{
    public class ProgrammerBuilder
    {
        private readonly string name = string.Empty;

        public Programmer WithSkill(string skillName)
        {
            var programmer = new Programmer(name);
            programmer.Learn(new Skill(skillName));
            return programmer;
        }
    }
}