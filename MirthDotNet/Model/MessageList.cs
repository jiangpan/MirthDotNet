using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("list")]
    public class MessageList
    {
        [XmlElement("message")]
        public List<Message> Messages { get; set; }
    }
}
