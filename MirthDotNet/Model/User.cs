using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class User
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("username")]
        public string Username { get; set; }
        [XmlElement("email")]
        public string Email { get; set; }
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [XmlElement("phoneNumber")]
        public string PhoneNumber { get; set; }
        [XmlElement("lastLogin")]
        public MirthDateTime LastLogin { get; set; }
    }
}
