using System.Linq;

namespace Domain.Test.DSL
{
    public class BacklogBuilder
    {
        private readonly Backlog backlog = new Backlog();

        public BacklogBuilder With(BacklogItem backlogItem)
        {
            backlog.Add(backlogItem);
            return this;
        }

        public BacklogBuilder With(string backlogItemName, params string[] componentNames)
        {
            var components = componentNames.Select(_ => new Component(_)).ToArray();
            var backlogItem = new BacklogItem(backlogItemName, components);
            backlog.Add(backlogItem);
            return this;
        }

        public Backlog Please => backlog;
        
        public static implicit operator Backlog(BacklogBuilder builder)
        {
            return builder.backlog;
        }
    }
}