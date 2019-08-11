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

            programmer.Learn("A");
            
            Assert.AreEqual("A", programmer.Skills);
        }
    }
}