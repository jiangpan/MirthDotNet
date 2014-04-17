using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class ChannelStatus
    {
        [XmlElement("channel")]
        public Channel Channel { get; set; }
        [XmlElement("deployedRevisionDelta")]
        public int DeployedRevisionDelta;
        [XmlElement("deployedDate")]
        public MirthDateTime DeployedDate;
    }
}
