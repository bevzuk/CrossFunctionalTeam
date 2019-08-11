using Domain;

namespace Tests.DSL
{
    public static class Create
    {
        public static ProgrammerBuilder Programmer => new ProgrammerBuilder();
    }

    public class ProgrammerBuilder
    {
        private readonly Programmer programmer = new Programmer();
        public Programmer WithSkill(string skillName)   
        {
            programmer.Learn(new Skill(skillName));
            return programmer;
        }
    }
}