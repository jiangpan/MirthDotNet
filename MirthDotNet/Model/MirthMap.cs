using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("map")]
    public class MirthMap
    {
        [XmlElement("entry")]
        public MirthMapItem[] MirthMapItem { get; set; }
    }

    [Serializable]
    [XmlRoot("entry")]
    public class MirthMapItem
    {
        [XmlElement("string")]
        public string Key { get; set; }
        [XmlElement("string-array")]
        public MirthStringArray Value { get; set; }
    }
}
