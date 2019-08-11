using System.Collections;
using Domain;
using NUnit.Framework;

namespace Tests
{
    public class TeamTests
    {
        [Test]
        public void CanAddProgrammer()
        {
            var team = new Team();
            var programmer = new Programmer();
            team.Add(programmer);
            
            var teamMembers = team.Members;
            
            CollectionAssert.AreEquivalent(new [] {programmer}, teamMembers);
        }
    }
}