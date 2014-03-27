using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("channelSummary")]
    public class ChannelSummary
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("added")]
        public string Added { get; set; }
        [XmlElement("deleted")]
        public string Deleted { get; set; }
    }
}
