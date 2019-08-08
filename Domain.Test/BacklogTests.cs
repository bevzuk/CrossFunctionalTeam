using System.Linq;
using Domain;
using NUnit.Framework;

namespace Tests
{
    public class BacklogTests
    {
        [Test]
        public void ByDefault_BacklogIsEmpty()
        {
            var backlog = new Backlog();

            var backlogItems = backlog.Items;

            CollectionAssert.IsEmpty(backlogItems);
        }
        
        [Test]
        public void CanAddUserStory()
        {
            var backlog = new Backlog();
            backlog.Add(new BacklogItem("US1"));
            
            var backlogItem = backlog.Items.Single();
            
            Assert.AreEqual("US1", backlogItem.Name);
        }

        [Test]
        public void CanAddUserStoryWithComponents()
        {
            var backlog = new Backlog();
            var component = new Component("A");
            var item = new BacklogItem("US1", component);
            backlog.Add(item);
            
            var backlogItem = backlog.Items.Single();
            
            Assert.AreEqual("A", backlogItem.Components);
        }

        [Test]
        public void CanAddUserStoryWithTwoComponents()
        {
            var backlog = new Backlog();
            var componentA = new Component("A");
            var componentB = new Component("B");
            var item = new BacklogItem("US1", componentA, componentB);
            backlog.Add(item);
            
            var backlogItem = backlog.Items.Single();
            
            Assert.AreEqual("AB", backlogItem.Components);
        }
    }
}