using System;
using System.ComponentModel;
using System.Linq;

namespace Domain
{
    public class BacklogItem
    {
        public readonly string Name;
        private readonly Component[] _components;

        public BacklogItem(string name, params Component[] components)
        {
            Name = name;
            _components = components;
        }

        public string Components => _components.Select(_ => _.Name).Aggregate(string.Empty, string.Concat);
    }
}