using Domain.Test.DSL;
using NUnit.Framework;

namespace Domain.Test
{
    public class CanCalculateStatisticsFor
    {
        [Test]
        public void OneBacklogItem_OneComponent_OneProgrammer()
        {
            var team = Create.Team.WithProgrammer("Homer", "A");
            var backlog = Create.Backlog
                .WithItem("US1", "A");
            var schedule = new Schedule(backlog, team);
            
            var statistics = schedule.CalculateStatistics();

            Assert.That(statistics.ThroughputRate, Is.EqualTo(1));
            Assert.That(statistics.LeadTime, Is.EqualTo(1));
        }
    }
}