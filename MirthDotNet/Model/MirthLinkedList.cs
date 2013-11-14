using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("linked-list")]
    public class MirthLinkedList
    {
        [XmlElement("string-array")]
        public MirthStringArray[] StringArrayItems { get; set; }
    }
}
