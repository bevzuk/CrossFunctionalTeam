using System;
using Domain;

namespace Tests.DSL
{
    public class BacklogBuilder
    {
        private readonly Backlog backlog = new Backlog();
        
        public BacklogBuilder With(Func<BacklogItemBuilder> buildBacklogItem)
        {
            backlog.Add(buildBacklogItem());
            return this;
        }

        public Backlog Please => backlog;
    }
}