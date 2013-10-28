using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MirthDotNet
{
    public class Operation
    {
        public Operation(string name, string displayName, bool auditable)
        {
            this.Name = name;
            this.DisplayName = displayName;
            this.Auditable = auditable;
        }

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool Auditable { get; set; }
    }
}
