using System.Collections;
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
    }
}