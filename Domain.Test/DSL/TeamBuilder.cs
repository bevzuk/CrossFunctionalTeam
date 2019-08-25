using Domain;

namespace Tests.DSL
{
    public class TeamBuilder
    {
        private readonly Team team = new Team();

        public TeamBuilder With(params Programmer[] programmers)
        {
            foreach (var programmer in programmers)
            {
                team.Add(programmer);
            }

            return this;
        }
        
        public TeamBuilder WithProgrammer(string name, params string[] skills)
        {
            var programmer = new Programmer(name);
            foreach (var skillName in skills)
            {
                programmer.Learn(new Skill(skillName));
            }
            team.Add(programmer);
            return this;
        }
        
        public TeamBuilder WithSomeProgrammer(params string[] skills)
        {
            var programmer = new Programmer();
            foreach (var skillName in skills)
            {
                programmer.Learn(new Skill(skillName));
            }
            team.Add(programmer);
            return this;
        }

        public Team Please => team;
        
        public static implicit operator Team(TeamBuilder builder)
        {
            return builder.team;
        }
    }
}