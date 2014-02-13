using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("messageFilter")]
    public class MessageFilter
    {
        [XmlElement("maxMessageId")]
        public long MaxMessageId { get; set; }
        //<contentSearch/>
        [XmlElement("attachment")]
        public bool Attachment { get; set; }
        [XmlElement("error")]
        public bool Error { get; set; }

        [XmlElement("startDate")]
        public MirthDateTime startDate { get; set; }
        [XmlIgnore()]
        public DateTime StartDate
        {
            set
            {
                startDate = new MirthDateTime();
                startDate.DateTime = value;
            }
        }
        [XmlElement("endDate")]
        public MirthDateTime endDate { get; set; }
        [XmlIgnore()]
        public DateTime EndDate
        {
            set
            {
                endDate = new MirthDateTime();
                endDate.DateTime = value;
            }
        }

        [XmlArray("statuses"), XmlArrayItem("com.mirth.connect.donkey.model.message.Status")]
        public List<string> Statuses;
    }
}
