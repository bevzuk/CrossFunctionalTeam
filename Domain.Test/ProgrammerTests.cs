using Domain;
using NUnit.Framework;
using Tests.DSL;

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
            var backlogItem = new BacklogItem("US1", 
                new Component("A"), new Component("B"));
            
            programmer.ChooseWorkFrom(backlogItem);
            
            Assert.AreEqual(new Component("A"), programmer.WorkingOn);
        }

        [Test]
        public void WhenNoWork_BeIdle()
        {
            var programmer = new Programmer();
            programmer.Learn(new Skill("A"));
            var backlogItem = new BacklogItem("US1", 
                new Component("B"));
            
            programmer.ChooseWorkFrom(backlogItem);
            
            Assert.AreEqual(Component.None, programmer.WorkingOn);
        }
        
        [Test]
        public void aslkjlakm()
        {
            var programmer1 = Create.Programmer.WithSkill("A");
            var programmer2 = Create.Programmer.WithSkill("A");
            var backlogItem = new BacklogItem("US1", 
                new Component("A"));
            
            programmer1.ChooseWorkFrom(backlogItem);
            programmer2.ChooseWorkFrom(backlogItem);
            
            Assert.AreEqual(new Component("A"), programmer1.WorkingOn);
            Assert.AreEqual(Component.None, programmer2.WorkingOn);
        }
    }
}