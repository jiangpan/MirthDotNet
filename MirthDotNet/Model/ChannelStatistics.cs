using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("channelStatistics")]
    public class ChannelStatistics
    {
        public String serverId { get; set; }
        public String channelId { get; set; }
        public long received { get; set; }
        public long sent { get; set; }
        public long error { get; set; }
        public long filtered { get; set; }
    }
}
