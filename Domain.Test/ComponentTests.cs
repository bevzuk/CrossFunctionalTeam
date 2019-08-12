using Domain;
using NUnit.Framework;

namespace Tests
{
    public class ComponentTests
    {
        [Test]
        public void ComponentIsNotEqualToNull()
        {
            var component = new Component("A");
            
            Assert.False(component == null);
        }
    }
}