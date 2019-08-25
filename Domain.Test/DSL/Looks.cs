using NUnit.Framework;

namespace Domain.Test.DSL
{
    internal class Looks : Is
    {
        public static ScheduleConstraint LikeSchedule(string expected)
        {
            return new ScheduleConstraint(expected);
        }

        public static WorkItemConstraint LikeWorkItem(string expected)
        {
            return new WorkItemConstraint(expected);
        }
    }
}