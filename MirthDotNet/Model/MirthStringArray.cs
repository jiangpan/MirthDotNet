using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("string-array")]
    public class MirthStringArray
    {
        [XmlElement("string")]
        public string[] Items { get; set; }
    }
}
