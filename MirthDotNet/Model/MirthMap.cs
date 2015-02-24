using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("map")]
    public class MirthMap<TEntry>
    {
        [XmlElement("entry")]
        public TEntry[] MirthMapItem { get; set; }
    }

    [Serializable]
    [XmlRoot("entry")]
    public class MirthMapItem
    {
        [XmlElement("string")]
        public string Key { get; set; }
        [XmlElement("string-array")]
        public MirthStringArray Value { get; set; }
    }

    [Serializable]
    [XmlRoot("entry")]
    public class MirthMapDashboardConnectorStateItem
    {
        [XmlElement("string")]
        public string Key { get; set; }
        [XmlElement("object-array")]
        public DashboardConnectorState Value { get; set; }
    }

    [Serializable]
    [XmlRoot("entry")]
    public class MirthMapStringIntItem
    {
        [XmlElement("string")]
        public string Key { get; set; }
        [XmlElement("int")]
        public int Int { get; set; }
    }

    [Serializable]
    [XmlRoot("entry")]
    public class MirthMapStringChannelHeaderItem
    {
        [XmlElement("string")]
        public string Key { get; set; }
        [XmlElement("channelHeader")]
        public ChannelHeader ChannelHeader { get; set; }
    }
}
