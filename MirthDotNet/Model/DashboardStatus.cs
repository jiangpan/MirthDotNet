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

        public string channelId;
        public string name;
        public DeployedState state;
        public int deployedRevisionDelta;
        //public DateTime deployedDate;
        public string deployedDate;
        //"com.mirth.connect.donkey.model.message.Status"
        //public Dictionary<Status, long> statistics;
        //public Dictionary<Status, long> lifetimeStatistics;
        public List<DashboardStatus> childStatuses = new List<DashboardStatus>();
        public int metaDataId;
        public bool queueEnabled;
        public long queued = 0l;
        public bool waitForPrevious = false;
        public HashSet<String> tags = new HashSet<String>();
        public StatusTypeEnum statusType;
    }
}
