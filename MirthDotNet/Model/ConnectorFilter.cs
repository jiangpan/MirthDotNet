using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class ConnectorFilter
    {
        [XmlArray("rules"), XmlArrayItem("rule")]
        public List<JavaScriptStep> Rules { get; set; }
    }
}
