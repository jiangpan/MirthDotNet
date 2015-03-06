using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MirthDotNet.Model;

namespace MirthDotNet.Plugins
{
    [Serializable]
    [XmlRoot("com.mirth.connect.plugins.history.model.Snapshot")]
    public class ChannelHistorySnapshot
    {
        [XmlElement("id")]
        public long Id { get; set; }
        [XmlElement("channelId")]
        public string ChannelId { get; set; }
        [XmlElement("revision")]
        public int Revision { get; set; }
        [XmlElement("userId")]
        public int UserId { get; set; }
        [XmlElement("dateCreated")]
        public MirthDateTime DateCreated { get; set; }
        [XmlElement("channel")]
        public string Channel { get; set; }
    }
}
