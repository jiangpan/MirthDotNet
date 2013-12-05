using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("linked-hash-map")]
    public class MirthLinkedHashMap<TEntry>
    {
        [XmlElement("entry")]
        public TEntry[] MirthHashMapItem { get; set; }
    }

    [Serializable]
    [XmlRoot("entry")]
    public class MirthIntLinkedHashMapItem
    {
        [XmlElement("int")]
        public int Key { get; set; }
        [XmlElement("string")]
        public string Value { get; set; }
    }
}
