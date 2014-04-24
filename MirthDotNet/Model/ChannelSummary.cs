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
        public string Id { get; set; } // deprecated in 3.0.1
        [XmlElement("channelId")]
        public string ChannelId { get; set; }
        public string GetChannelId() { return !string.IsNullOrWhiteSpace(ChannelId) ? ChannelId : Id; }
        [XmlElement("added")]
        public string Added { get; set; }
        [XmlElement("deleted")]
        public string Deleted { get; set; }
        [XmlElement("undeployed")]
        public string Undeployed { get; set; }
        [XmlElement("channelStatus")]
        public ChannelStatus ChannelStatus { get; set; }
    }
}
