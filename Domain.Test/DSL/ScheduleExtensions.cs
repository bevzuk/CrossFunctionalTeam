using System;
using System.Linq;

namespace Domain.Test.DSL
{
    public static class ScheduleExtensions
    {
        public static string AsString(this Schedule schedule)
        {
            var teamMembers =
                $"{Environment.NewLine}|   |{string.Join('|', schedule.TeamMembers.Select(_ => _.Name))}|";
            var firstDaySchedule = string.Join('|', schedule.Data.Select(_ => _.BacklogItem + "." + _.Component));
            return
                $"{teamMembers}{Environment.NewLine}| 1 |{firstDaySchedule}|";
        }
    }
}