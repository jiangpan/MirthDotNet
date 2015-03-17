using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class JavaScriptStep
    {
        [XmlElement("sequenceNumber")]
        public int SequenceNumber { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("type")]
        public string Type { get; set; }
        [XmlElement("script")]
        public string Script { get; set; }
        [XmlElement("operator")]
        public string Operator { get; set; }
    }
}
