using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class ConnectorTransformer
    {
        [XmlArray("steps"), XmlArrayItem("step")]
        public List<JavaScriptStep> Steps { get; set; }

        [XmlElement("inboundTemplate")]
        public string InboundTemplateBase64 { get; set; }
        [XmlElement("InboundDataType")]
        public string InboundDataType { get; set; }

        [XmlElement("outboundDataType")]
        public string OutboundDataTypeBase64 { get; set; }
        [XmlElement("OutboundDataType")]
        public string OutboundDataType { get; set; }
    }
}
