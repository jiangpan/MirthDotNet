using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Plugins
{
    [Serializable]
    [XmlRoot("list")]
    public class ChannelHistorySnapshotList
    {
        [XmlElement("com.mirth.connect.plugins.history.model.Snapshot")]
        public List<ChannelHistorySnapshot> Snapshots { get; set; }
    }
}
