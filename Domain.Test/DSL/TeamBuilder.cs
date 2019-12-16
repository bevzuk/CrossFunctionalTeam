using System.Collections.Generic;
using Domain.TeamWorkStrategy;

namespace Domain.Test.DSL {
    public class TeamBuilder {
        private ITeamWorkStrategy strategy = new IgnoreBacklogOrderTeamWorkStrategy();
        private readonly List<Programmer> programmers = new List<Programmer>();

        public Team Please {
            get {
                var team = new Team(strategy);
                team.Add(programmers.ToArray());
                return team;
            }
        }

        public TeamBuilder WithRespectWipLimitIgnoreBacklogOrderTeamWorkStrategy(int wipLimit) {
            strategy = new RespectWipLimitIgnoreBacklogOrderTeamWorkStrategy(wipLimit);
            return this;
        }

        public TeamBuilder WithRespectWipLimitRespectBacklogOrderTeamWorkStrategy(int wipLimit) {
            strategy = new RespectWipLimitRespectBacklogOrderTeamWorkStrategy(wipLimit);
            return this;
        }

        public TeamBuilder With(params Programmer[] theProgrammers) {
            programmers.AddRange(theProgrammers);
            return this;
        }

        public TeamBuilder WithProgrammer(string name, params string[] skills) {
            var programmer = new Programmer(name);
            foreach (var skillName in skills) programmer.Learn(new Skill(skillName));
            programmers.Add(programmer);
            return this;
        }

        public static implicit operator Team(TeamBuilder builder) {
            return builder.Please;
        }
    }
}