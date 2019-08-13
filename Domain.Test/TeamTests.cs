using System.Collections;
using Domain;
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
            var team = Create.Team
                .WithProgrammers(Create.Programmer.WithSkill("A"))
                .Please;
            var backlog = Create.Backlog
                .With(() => Create.BacklogItem("US1").WithComponent("A"))
                .With(() => Create.BacklogItem("US2").WithComponent("A"))
                .Please;

            team.WorkOn(backlog);

            Assert.That(team.Statistics.ThroughputRate, Is.EqualTo(2));
        }

        [Test]
        public void TeamCanDistributeWorkAcrossProgrammersForDay()
        {
            var programmerA = Create.Programmer.WithSkill("A");
            var programmerB = Create.Programmer.WithSkill("B");
            var team = Create.Team.WithProgrammers(programmerA, programmerB).Please;
            var backlog = Create.Backlog
                .With(() => Create.BacklogItem("US1").WithComponent("A").WithComponent("B"))
                .Please;

            team.DistributeWork(backlog);

            Assert.That(programmerA.WorkingOn, Is.EqualTo(new Component("A")));
            Assert.That(programmerB.WorkingOn, Is.EqualTo(new Component("B")));
        }

        [Test]
        public void TeamCanDistributeTwoBacklogItemsAcrossProgrammersForDay()
        {
            var programmerA = Create.Programmer.WithSkill("A");
            var programmerB = Create.Programmer.WithSkill("B");
            var team = Create.Team.WithProgrammers(programmerA, programmerB).Please;
            var backlog = Create.Backlog
                .With(() => Create.BacklogItem("US1").WithComponent("A"))
                .With(() => Create.BacklogItem("US2").WithComponent("B"))
                .Please;

            team.DistributeWork(backlog);

            Assert.That(programmerA.WorkingOn, Is.EqualTo(new Component("A")));
            Assert.That(programmerB.WorkingOn, Is.EqualTo(new Component("B")));
        }

        [Test]
        public void TeamCanDistributeThreeBacklogItemsAcrossThreeProgrammers()
        {
            var programmerA = Create.Programmer.WithSkill("A");
            var programmerB = Create.Programmer.WithSkill("B");
            var programmerC = Create.Programmer.WithSkill("C");
            var team = Create.Team.WithProgrammers(programmerA, programmerB, programmerC).Please;
            var backlog = Create.Backlog
                .With(() => Create.BacklogItem("US1").WithComponent("A").WithComponent("A").WithComponent("B"))
                .With(() => Create.BacklogItem("US2").WithComponent("A").WithComponent("B").WithComponent("B"))
                .With(() => Create.BacklogItem("US3").WithComponent("A").WithComponent("B").WithComponent("C"))
                .Please;

            team.DistributeWork(backlog);

            Assert.That(programmerA.WorkingOn, Is.EqualTo(new Component("A")));
            Assert.That(programmerB.WorkingOn, Is.EqualTo(new Component("B")));
            Assert.That(programmerC.WorkingOn, Is.EqualTo(new Component("C")));
        }
    }
}