using Domain;
using NUnit.Framework;

namespace Tests
{
    public class ProgrammerTests
    {
        [Test]
        public void ProgrammerCanLearnSkillA()
        {
            var programmer = new Programmer();

            programmer.Learn(new Skill("A"));
            
            Assert.AreEqual(new Skill("A"), programmer.Skill);
        }
        
        [Test]
        public void ProgrammerCanLearnSkillB()
        {
            var programmer = new Programmer();

            programmer.Learn(new Skill("B"));
            
            Assert.AreEqual(new Skill("B"), programmer.Skill);
        }

        [Test]
        public void CanChooseWork()
        {
            var programmer = new Programmer();
            programmer.Learn(new Skill("A"));
            var componentA = new Component("A");
            var backlogItem = new BacklogItem("US1", 
                componentA, new Component("B"));
            
            programmer.ChooseWorkFrom(backlogItem);
            
            Assert.AreEqual(componentA, programmer.WorkingOn);
        }
    }
}