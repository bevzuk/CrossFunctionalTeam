using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Tests.DSL
{
    public class BacklogItemBuilder
    {
        private readonly string name;
        private readonly List<string> componentNames = new List<string>();

        public BacklogItemBuilder(string name)
        {
            this.name = name;
        }

        public BacklogItemBuilder WithComponent(string name)
        {
            componentNames.Add(name);
            return this;
        }

        public static implicit operator BacklogItem(BacklogItemBuilder builder)
        {
            return new BacklogItem(builder.name, builder.componentNames.Select(_ => new Component(_)).ToArray());
        }
    }
}