using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Domain
{
    public class Schedule
    {
        private Backlog backlog;
        private Team team;

        public Schedule(Backlog backlog, Team team)
        {
            this.backlog = backlog;
            this.team = team;

            CalculateSchedule();
        }

        public IReadOnlyCollection<Programmer> TeamMembers => team.Members;

        public IReadOnlyCollection<ScheduleData> Data => data.AsReadOnly();
        private readonly List<ScheduleData> data = new List<ScheduleData>(); 

        private void CalculateSchedule()
        {
            team.DistributeWork(backlog);
            data.Add(new ScheduleData("US1", team.Members.First().WorkingOn.Name));
        }
    }
}