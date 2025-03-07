using Domain.Test.DSL;
using NUnit.Framework;
using System.Linq;

namespace Domain.Test {
    public class ProgrammerTests {
        [TestCase("A")]
        [TestCase("B")]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("C#")]
        [TestCase("Java Script")]
        public void ProgrammerCanLearnSkill(string skillName) {
            var programmer = Create.Programmer.Please;

            programmer.Learn(new Skill(skillName));

            Assert.AreEqual(new Skill(skillName), programmer.Skills.Single());
        }

        [Test]
        public void ProgrammerCanLearnMultipleSkills() {
            var programmer = Create.Programmer.Please;
            var skillA = new Skill("A");
            var skillB = new Skill("B");

            programmer.Learn(skillA);
            programmer.Learn(skillB);

            CollectionAssert.AreEquivalent(
                new[] { skillA, skillB },
                programmer.Skills
            );
        }
    }
}