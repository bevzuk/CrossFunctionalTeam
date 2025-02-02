using NUnit.Framework;

namespace Domain.Test {
    public class ComponentTests {
        [Test]
        public void ComponentIsNotEqualToNull() {
            var component = new Component("A");

            Assert.That(component, Is.Not.Null);
        }
    }
}