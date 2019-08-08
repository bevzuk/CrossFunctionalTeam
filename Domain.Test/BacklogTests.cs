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
    }
}