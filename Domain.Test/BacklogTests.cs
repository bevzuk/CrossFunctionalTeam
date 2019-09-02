using System.Linq;
using NUnit.Framework;

namespace Domain.Test
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
        public void CanAddTwoUserStories()
        {
            var backlog = new Backlog();
            backlog.Add(new BacklogItem("US1"));
            backlog.Add(new BacklogItem("US2"));

            var backlogItems = backlog.Items;

            CollectionAssert.AreEqual(
                new[]
                {
                    new BacklogItem("US1"),
                    new BacklogItem("US2")
                },
                backlogItems);
        }

        [Test]
        public void CanAddUserStoryWithComponents()
        {
            var backlog = new Backlog();
            var component = new Component("A");
            var item = new BacklogItem("US1", component);
            backlog.Add(item);

            var backlogItem = backlog.Items.Single();

            Assert.AreEqual(new Component("A"), backlogItem.FindComponentFor(new Skill("A")));
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

            Assert.AreEqual(new Component("A"), backlogItem.FindComponentFor(new Skill("A")));
            Assert.AreEqual(new Component("B"), backlogItem.FindComponentFor(new Skill("B")));
        }
    }
}