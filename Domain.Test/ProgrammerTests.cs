using Domain.Test.DSL;
using NUnit.Framework;

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

        [Test]
        public void WhenProgrammerStartsWorking_IsWorkingBecomesTrue() {
            var programmer = Create.Programmer.Please;
            programmer.Learn(new Skill("A"));
            var backlogItem = new BacklogItem("US1", new Component("A"));

            programmer.WorkOn(backlogItem);

            Assert.That(programmer.IsWorking, Is.True);
            Assert.That(programmer.WorkItem.BacklogItem, Is.EqualTo(backlogItem));
            Assert.That(programmer.WorkItem.Component, Is.EqualTo(new Component("A")));
        }

        [Test]
        public void WhenProgrammerDoesNothing_IsWorkingBecomesFalse() {
            var programmer = Create.Programmer.Please;
            programmer.Learn(new Skill("A"));
            var backlogItem = new BacklogItem("US1", new Component("A"));
            programmer.WorkOn(backlogItem);

            programmer.DoNothing();

            Assert.That(programmer.IsWorking, Is.False);
            Assert.That(programmer.WorkItem.Component, Is.EqualTo(Component.None));
        }

        [Test]
        public void WhenProgrammerHasNoRequiredSkills_CannotWorkOnBacklogItem() {
            var programmer = Create.Programmer.Please;
            programmer.Learn(new Skill("A"));
            var backlogItem = new BacklogItem("US1", new Component("B"));

            programmer.WorkOn(backlogItem);

            Assert.That(programmer.IsWorking, Is.False);
            Assert.That(programmer.WorkItem.Component, Is.EqualTo(Component.None));
        }

        [Test]
        public void HasSkillsFor_ReturnsTrueWhenProgrammerHasRequiredSkill() {
            var programmer = Create.Programmer.Please;
            programmer.Learn(new Skill("A"));
            var backlogItem = new BacklogItem("US1", new Component("A"));

            var hasSkills = programmer.HasSkillsFor(backlogItem);

            Assert.That(hasSkills, Is.True);
        }

        [Test]
        public void HasSkillsFor_ReturnsFalseWhenProgrammerLacksRequiredSkill() {
            var programmer = Create.Programmer.Please;
            programmer.Learn(new Skill("A"));
            var backlogItem = new BacklogItem("US1", new Component("B"));

            var hasSkills = programmer.HasSkillsFor(backlogItem);

            Assert.That(hasSkills, Is.False);
        }
    }
}