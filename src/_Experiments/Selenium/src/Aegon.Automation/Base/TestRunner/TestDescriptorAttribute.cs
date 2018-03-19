using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegon.Base.TestRunner
{
    internal class TestDescriptorAttribute : Attribute
    {
        public string ID { get; set; }
        public bool Ignored { get; set; }
        public bool Name { get; set; } 
        public string Description { get; set; }
    }
}
