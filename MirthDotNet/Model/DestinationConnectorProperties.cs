using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class DestinationConnectorProperties
    {
        [XmlElement("queueEnabled")]
        public bool queueEnabled { get; set; }
        [XmlElement("sendFirst")]
        public bool sendFirst { get; set; }
    }
}
