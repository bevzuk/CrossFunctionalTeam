using Domain.Test.DSL;
using NUnit.Framework;

namespace Domain.Test {
    public class ProgrammerTests {
        [Test]
        public void ProgrammerCanLearnSkillA() {
            var programmer = Create.Programmer.Please;

            programmer.Learn(new Skill("A"));

            Assert.AreEqual(new Skill("A"), programmer.Skills.Single());
        }

        [Test]
        public void ProgrammerCanLearnSkillB() {
            var programmer = Create.Programmer.Please;

            programmer.Learn(new Skill("B"));

            Assert.AreEqual(new Skill("B"), programmer.Skills.Single());
        }
    }
}