using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class TransmissionModeProperties
    {
        [XmlElement("pluginPointName")]
        public string PluginPointName { get; set; }
        [XmlElement("startOfMessageBytes")]
        public string StartOfMessageBytes { get; set; }
        [XmlElement("endOfMessageBytes")]
        public string EndOfMessageBytes { get; set; }
        [XmlElement("useMLLPv2")]
        public bool UseMLLPv2 { get; set; }
    }
}
