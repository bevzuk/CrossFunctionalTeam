using Domain.TeamWorkStrategy;

namespace Domain.Test.DSL
{
    public class TeamBuilder
    {
        public Team Please { get; } = new Team(new DoWhateverICanTeamWorkStrategy());

        public TeamBuilder With(params Programmer[] programmers)
        {
            foreach (var programmer in programmers) Please.Add(programmer);
            return this;
        }

        public TeamBuilder WithProgrammer(string name, params string[] skills)
        {
            var programmer = new Programmer(name);
            foreach (var skillName in skills) programmer.Learn(new Skill(skillName));
            Please.Add(programmer);
            return this;
        }

        public static implicit operator Team(TeamBuilder builder)
        {
            return builder.Please;
        }
    }
}