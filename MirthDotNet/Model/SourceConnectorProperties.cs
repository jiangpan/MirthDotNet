using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class SourceConnectorProperties
    {
        /// <summary>
        /// If false, then queue enabled
        /// </summary>
        [XmlElement("respondAfterProcessing")]
        public bool RespondAfterProcessing { get; set; }
        [XmlElement("responseVariable")]
        public string ResponseVariable { get; set; }
    }
}
