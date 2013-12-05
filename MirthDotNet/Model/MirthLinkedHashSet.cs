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
        [XmlElement("string")]
        public HashSet<string> Items { get; set; }
    }
}
