using System.Linq;

namespace Domain.Test.DSL
{
    public class BacklogBuilder
    {
        private readonly Backlog backlog = new Backlog();

        public BacklogBuilder WithItem(string name, params string[] components)
        {
            backlog.Add(new BacklogItem(name, components.Select(_ => new Component(_)).ToArray()));
            return this;
        }

        public static implicit operator Backlog(BacklogBuilder builder)
        {
            return builder.backlog;
        }
    }
}