using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class ChannelHeader
    {
        [XmlElement("revision")]
        public int Revision { get; set; }

        [XmlElement("deployedDate")]
        public MirthDateTime deployedDate { get; set; }
        [XmlIgnore()]
        public DateTime DeployedDate
        {
            set
            {
                deployedDate = new MirthDateTime();
                deployedDate.DateTime = value;
            }
        }
    }
}
