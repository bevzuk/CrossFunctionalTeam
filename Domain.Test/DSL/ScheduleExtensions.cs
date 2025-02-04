using System.Text;

namespace Domain.Test.DSL {
    public static class ScheduleExtensions {
        public static string AsString(this Schedule schedule) {
            var result = new StringBuilder();

            var teamMembers =
                $"{Environment.NewLine}|   | {string.Join(" | ", schedule.TeamMembers.Select(_ => _.Name))} |";
            result.AppendLine(teamMembers);

            var days = schedule.Data.Select(_ => _.Day).Distinct().OrderBy(_ => _);
            foreach (var day in days) {
                var work = string.Join(" | ",
                                       schedule.Data.Where(_ => _.Day == day)
                                          .Select(_ => $"{_.BacklogItem}.{_.Component}"));
                result.AppendLine($"| {day} | {work} |");
            }

            return result.ToString();
        }
    }
}