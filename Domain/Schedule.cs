using System.Collections.Generic;

namespace Domain
{
    public class Schedule
    {
        private readonly Backlog backlog;
        private readonly List<ScheduleData> data = new List<ScheduleData>();
        private readonly Team team;

        public Schedule(Backlog backlog, Team team)
        {
            this.backlog = backlog;
            this.team = team;

            CalculateSchedule();
        }

        public IReadOnlyCollection<Programmer> TeamMembers => team.Members;
        public IReadOnlyCollection<ScheduleData> Data => data.AsReadOnly();

        private void CalculateSchedule()
        {
            team.DistributeWork(backlog);
            foreach (var teamMember in team.Members)
                data.Add(new ScheduleData(teamMember.WorkItem.BacklogItem.Name, teamMember.WorkItem.Component.Name));
        }
    }
}