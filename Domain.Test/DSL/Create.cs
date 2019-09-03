namespace Domain.Test.DSL
{
    public static class Create
    {
        public static ProgrammerBuilder Programmer => new ProgrammerBuilder();
        public static TeamBuilder Team => new TeamBuilder();
        public static BacklogBuilder Backlog => new BacklogBuilder();
        public static WorkItemBuilder WorkItem => new WorkItemBuilder();
    }
}