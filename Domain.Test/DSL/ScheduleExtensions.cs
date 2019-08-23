namespace Domain.Test.DSL
{
    public static class ScheduleExtensions
    {
        public static string AsString(this Schedule schedule)
        {
            return @"
|   | A     |
| 1 | US1.A |";
        }
    }
}