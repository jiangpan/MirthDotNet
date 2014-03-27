using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("list")]
    public class ChannelList
    {
        public ChannelList()
        {
            this.Channels = new List<Channel>();
        }

        [XmlElement("channel")]
        public List<Channel> Channels { get; set; }
    }
}
