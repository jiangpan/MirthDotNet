using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class Connector
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlElement("metaDataId")]
        public string MetaDataId { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("transportName")]
        public string TransportName { get; set; }
        [XmlElement("mode")]
        public string Mode { get; set; }
        [XmlElement("enabled")]
        public bool Enabled { get; set; }
        [XmlElement("waitForPrevious")]
        public bool WaitForPrevious { get; set; }
    }
}
