using System.Collections.Generic;

namespace Domain.Test.DSL {
    public class ProgrammerBuilder {
        private readonly string name = string.Empty;
        private readonly List<Skill> skills = new List<Skill>();

        public Programmer Please => this;

        public ProgrammerBuilder WithSkill(string skillName) {
            skills.Add(new Skill(skillName));
            return this;
        }

        public ProgrammerBuilder WithSkills(params string[] theSkills) {
            foreach (var skill in theSkills) WithSkill(skill);
            return this;
        }

        public static implicit operator Programmer(ProgrammerBuilder builder) {
            var programmer = new Programmer(builder.name);
            builder.skills.ForEach(programmer.Learn);
            return programmer;
        }
    }
}