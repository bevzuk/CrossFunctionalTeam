using Domain;
using Domain.Test.DSL;
using NUnit.Framework;
using Tests.DSL;

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
            CollectionAssert.AreEquivalent(new[] {programmer1, programmer2}, teamMembers);
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

        [Test]
        public void CanWorkOnBacklogWithTwoItems()
        {
            var team = Create.Team.WithSomeProgrammer("A").Please;
            var backlog = Create.Backlog
                .WithItem("US2", "A")
                .WithItem("US1", "A");

            team.WorkOn(backlog);

            Assert.That(team.Statistics.ThroughputRate, Is.EqualTo(2));
        }

        [Test]
        public void TeamCanDistributeWorkAcrossProgrammersForDay()
        {
            var programmerA = Create.Programmer.WithSkill("A");
            var programmerB = Create.Programmer.WithSkill("B");
            var team = Create.Team.With(programmerA, programmerB).Please;
            var backlog = Create.Backlog
                .WithItem("US1", "A", "B");

            team.DistributeWork(backlog);

            Assert.That(programmerA.WorkItem, Looks.LikeWorkItem("US1.A"));
            Assert.That(programmerB.WorkItem, Looks.LikeWorkItem("US1.B"));
        }

        [Test]
        public void TeamCanDistributeTwoBacklogItemsAcrossProgrammersForDay()
        {
            var programmerA = Create.Programmer.WithSkill("A");
            var programmerB = Create.Programmer.WithSkill("B");
            var team = Create.Team.With(programmerA, programmerB).Please;
            var backlog = Create.Backlog
                .WithItem("US1", "A")
                .WithItem("US2", "B");

            team.DistributeWork(backlog);

            Assert.That(programmerA.WorkItem, Looks.LikeWorkItem("US1.A"));
            Assert.That(programmerB.WorkItem, Looks.LikeWorkItem("US2.B"));
        }

        [Test]
        public void TeamCanDistributeThreeBacklogItemsAcrossThreeProgrammers()
        {
            var programmerA = Create.Programmer.WithSkill("A");
            var programmerB = Create.Programmer.WithSkill("B");
            var programmerC = Create.Programmer.WithSkill("C");
            var team = Create.Team.With(programmerA, programmerB, programmerC).Please;
            var backlog = Create.Backlog
                .WithItem("US1", "A", "B")
                .WithItem("US2", "C");

            team.DistributeWork(backlog);

            Assert.That(programmerA.WorkItem, Looks.LikeWorkItem("US1.A"));
            Assert.That(programmerB.WorkItem, Looks.LikeWorkItem("US1.B"));
            Assert.That(programmerC.WorkItem, Looks.LikeWorkItem("US2.C"));
        }
    }
}