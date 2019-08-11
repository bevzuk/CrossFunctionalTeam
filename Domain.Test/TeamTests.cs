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
            CollectionAssert.AreEquivalent(new[] {programmer}, teamMembers);
        }

        [Test]
        public void CanAddTwoProgrammers()
        {
            var team = new Team();
            var programmer1 = new Programmer();
            var programmer2 = new Programmer();

            team.Add(programmer1, programmer2);

            var teamMembers = team.Members;
            CollectionAssert.AreEquivalent(new [] {programmer1, programmer2}, teamMembers);
        }

        [Test]
        public void ByDefault_TeamStatistics_IsZero()
        {
            var team = new Team();
            
            var statistics = team.Statistics;
            
            Assert.AreEqual(0, statistics.LeadTime);
            Assert.AreEqual(0, statistics.ThroughputRate);
        }

        [Test]
        public void CanWorkOnSingleBacklogItem()
        {
            var team = new Team();
            var programmer = new Programmer();
            programmer.Learn(new Skill("A"));
            team.Add(programmer);
            var backlog = new Backlog();
            backlog.Add(new BacklogItem("US1", new Component("A")));
            
            team.WorkOn(backlog);
            
            var statistics = team.Statistics;
            Assert.AreEqual(1, statistics.ThroughputRate);
        }
    }
}