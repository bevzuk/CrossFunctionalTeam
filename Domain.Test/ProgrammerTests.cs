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
            
            Assert.AreEqual(new Component("A"), programmer.WorkingOnComponent);
        }

        [Test]
        public void WhenNoWork_BeIdle()
        {
            var programmer = new Programmer();
            programmer.Learn(new Skill("A"));
            var backlogItem = new BacklogItem("US1", 
                new Component("B"));
            
            programmer.ChooseWorkFrom(backlogItem);
            
            Assert.AreEqual(Component.None, programmer.WorkingOnComponent);
        }
        
        [Test]
        public void When2ProgrammersDo1PBI_Programmer2HasNoWork()
        {
            var programmer1 = Create.Programmer.WithSkill("A");
            var programmer2 = Create.Programmer.WithSkill("A");
            var backlogItem = new BacklogItem("US1", 
                new Component("A"));
            
            programmer1.ChooseWorkFrom(backlogItem);
            programmer2.ChooseWorkFrom(backlogItem);
            
            Assert.AreEqual(new Component("A"), programmer1.WorkingOnComponent);
            Assert.AreEqual(Component.None, programmer2.WorkingOnComponent);
        }
        
        [Test]
        public void CanChooseWorkFromBacklog()
        {
            var programmer = new Programmer();
            programmer.Learn(new Skill("A"));
            var backlog = new Backlog();
            backlog.Add(new BacklogItem("US1", 
                new Component("A"), new Component("B")));
            
            programmer.ChooseWorkFrom(backlog);
            
            Assert.AreEqual(new Component("A"), programmer.WorkingOnComponent);
        }

        
    }
}