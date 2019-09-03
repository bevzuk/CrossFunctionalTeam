using Domain.Test.DSL;
using NUnit.Framework;

namespace Domain.Test
{
    public class CanCalculateStatisticsFor
    {
        [Test]
        public void OneBacklogItem_OneComponent()
        {
            var scheduleData = new[]
            {
                new ScheduleData(1, Create.WorkItem.WithBacklogItem("US1", "A").WithComponent("A"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(1, 1)));
        }
    }
}