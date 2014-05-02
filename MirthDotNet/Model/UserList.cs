using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("list")]
    public class UserList
    {
        [XmlElement("user")]
        public List<User> Users { get; set; }
    }
}
