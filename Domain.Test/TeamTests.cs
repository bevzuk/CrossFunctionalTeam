using Domain.Test.DSL;
using NUnit.Framework;

namespace Domain.Test
{
    public class TeamTests
    {
        [Test]
        public void CanAddProgrammer()
        {
            var programmer = new Programmer();
            var team = Create.Team.With(programmer).Please;

            var teamMembers = team.Members;

            CollectionAssert.AreEquivalent(new[] {programmer}, teamMembers);
        }

        [Test]
        public void CanAddTwoProgrammers()
        {
            var programmer1 = new Programmer();
            var programmer2 = new Programmer();
            var team = Create.Team.With(programmer1, programmer2).Please;

            var teamMembers = team.Members;

            CollectionAssert.AreEquivalent(new[] {programmer1, programmer2}, teamMembers);
        }

        [Test]
        public void TeamCanDistributeWorkAcrossProgrammersForDay()
        {
            var programmerA = Create.Programmer.WithSkill("A").Please;
            var programmerB = Create.Programmer.WithSkill("B").Please;
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
            var programmerA = Create.Programmer.WithSkill("A").Please;
            var programmerB = Create.Programmer.WithSkill("B").Please;
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
            var programmerA = Create.Programmer.WithSkill("A").Please;
            var programmerB = Create.Programmer.WithSkill("B").Please;
            var programmerC = Create.Programmer.WithSkill("C").Please;
            var team = Create.Team.With(programmerA, programmerB, programmerC).Please;
            var backlog = Create.Backlog
                .WithItem("US1", "A", "B")
                .WithItem("US2", "C");

            team.DistributeWork(backlog);

            Assert.That(programmerA.WorkItem, Looks.LikeWorkItem("US1.A"));
            Assert.That(programmerB.WorkItem, Looks.LikeWorkItem("US1.B"));
            Assert.That(programmerC.WorkItem, Looks.LikeWorkItem("US2.C"));
        }


        [Test]
        public void SecondWorkDistribution_DistributesSecondWorkItem()
        {
            var homer = Create.Programmer.WithSkill("A").Please;
            var team = Create.Team.With(homer).Please;
            var backlog = Create.Backlog
                .WithItem("US1", "A")
                .WithItem("US2", "A");

            team.DistributeWork(backlog);
            team.DistributeWork(backlog);

            Assert.That(homer.WorkItem, Looks.LikeWorkItem("US2.A"));
        }

        [Test]
        public void TShapedTeam_CanWorkOnMultipleComponents()
        {
            var homer = Create.Programmer.WithSkills("A", "B").Please;
            var marge = Create.Programmer.WithSkills("A", "B").Please;
            var team = Create.Team.With(homer, marge).Please;
            var backlog = Create.Backlog
                .WithItem("US1", "A", "B");

            team.DistributeWork(backlog);

            Assert.That(homer.WorkItem, Looks.LikeWorkItem("US1.A"));
            Assert.That(marge.WorkItem, Looks.LikeWorkItem("US1.B"));
        }
    }
}