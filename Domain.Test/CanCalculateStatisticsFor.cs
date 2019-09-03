using Domain.Test.DSL;
using NUnit.Framework;

namespace Domain.Test
{
    public class CanCalculateStatisticsFor
    {
        [Test]
        public void OneBacklogItem_OneComponent_OneDay()
        {
            var scheduleData = new[]
            {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(1, 1)));
        }

        [Test]
        public void OneBacklogItem_OneComponent_TwoDays()
        {
            var scheduleData = new[]
            {
                new ScheduleData(1, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("A")),
                new ScheduleData(2, Create.WorkItem.ForBacklogItem("US1").WorkOnComponent("B"))
            };

            var statistics = new StatisticsCalculator().Calculate(scheduleData);

            Assert.That(statistics, Is.EqualTo(new Statistics(1 / 2f, 2)));
        }
    }
}