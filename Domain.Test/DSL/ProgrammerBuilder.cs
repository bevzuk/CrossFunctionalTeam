using Domain;

namespace Tests.DSL
{
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