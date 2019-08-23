using System;
using System.Linq;

namespace Domain.Test.DSL
{
    public static class ScheduleExtensions
    {
        public static string AsString(this Schedule schedule)
        {
            var teamMembers = "|   |" + string.Join('|', schedule.TeamMembers.Select(_ => _.Name)) + "|";
            return teamMembers + Environment.NewLine +  "| 1 |" + schedule.Data.Select(_ => _.BacklogItem + "." + _.Component).First() + "|";
        }
    }
}