using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionsLib.Components
{
    [Serializable]
    public class SimpleItem
    {
        public SimpleItem()
        {
        }

        public SimpleItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
