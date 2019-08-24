namespace Domain.Test.DSL
{
    internal class Looks : NUnit.Framework.Is
    {
        public static ScheduleConstraint Like(string expected)
        {
            return new ScheduleConstraint(expected);
        }
    }
}