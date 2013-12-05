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
    }
}
