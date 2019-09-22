using System.Linq;
using NUnit.Framework;

namespace Domain.Test {
    public class ProgrammerTests {
        [Test]
        public void ProgrammerCanLearnSkillA() {
            var programmer = new Programmer();

            programmer.Learn(new Skill("A"));

            Assert.AreEqual(new Skill("A"), programmer.Skills.Single());
        }

        [Test]
        public void ProgrammerCanLearnSkillB() {
            var programmer = new Programmer();

            programmer.Learn(new Skill("B"));

            Assert.AreEqual(new Skill("B"), programmer.Skills.Single());
        }
    }
}