using Domain;

namespace Tests.DSL
{
    public class TeamBuilder
    {
        private readonly Team team = new Team();

        public TeamBuilder WithProgrammers(params Programmer[] programmers)
        {
            foreach (var programmer in programmers)
            {
                team.Add(programmer);
            }

            return this;
        }

        public Team Please => team;
    }
}