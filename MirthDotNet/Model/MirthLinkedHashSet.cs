using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("linked-hash-set")]
    public class MirthLinkedHashSet
    {
        public MirthLinkedHashSet() { }
        public MirthLinkedHashSet(HashSet<string> items)
        {
            this.Items = items;
        }

        [XmlElement("string")]
        public HashSet<string> Items { get; set; }
    }
}
