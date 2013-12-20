using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("com.mirth.connect.model.DashboardStatus")]
    public class DashboardStatus
    {
        public enum StatusTypeEnum
        {
            CHANNEL, CHAIN, SOURCE_CONNECTOR, DESTINATION_CONNECTOR
        };

        [XmlElement("channelId")]
        public string ChannelId;
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("state")]
        public DeployedState State;
        [XmlElement("deployedRevisionDelta")]
        public int DeployedRevisionDelta;
        [XmlElement("deployedDate")]
        public MirthDateTime DeployedDate;
        [XmlArray("statistics"), XmlArrayItem("entry")]
        public List<StatisticsEntry> Statistics;
        [XmlArray("lifetimeStatistics"), XmlArrayItem("entry")]
        public List<StatisticsEntry> LifetimeStatistics;
        [XmlElement("childStatuses")]
        public DashboardStatusList ChildStatuses = new DashboardStatusList();
        [XmlElement("metaDataId")]
        public int MetaDataId;
        [XmlElement("queueEnabled")]
        public bool QueueEnabled;
        [XmlElement("queued")]
        public long Queued = 0l;
        [XmlElement("waitForPrevious")]
        public bool WaitForPrevious = false;
        [XmlArray("tags"), XmlArrayItem("string")]
        public HashSet<string> Tags = new HashSet<string>();
        [XmlElement("statusType")]
        public StatusTypeEnum StatusType;

        [XmlRoot("entry")]
        public class StatisticsEntry
        {
            [XmlElement("com.mirth.connect.donkey.model.message.Status")]
            public string Name { get; set; }
            [XmlElement("long")]
            public long Count { get; set; }
        }
    }
}
