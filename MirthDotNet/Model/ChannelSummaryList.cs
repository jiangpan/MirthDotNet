using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("list")]
    public class ChannelSummaryList
    {
        public ChannelSummaryList()
        {
            this.Channels = new List<ChannelSummary>();
        }

        [XmlElement("channelSummary")]
        public List<ChannelSummary> Channels { get; set; }
    }
}
