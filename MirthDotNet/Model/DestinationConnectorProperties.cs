using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class DestinationConnectorProperties
    {
        [XmlElement("queueEnabled")]
        public bool QueueEnabled { get; set; }
        [XmlElement("sendFirst")]
        public bool SendFirst { get; set; }
        [XmlElement("retryIntervalMillis")]
        public int RetryIntervalMillis { get; set; }
        [XmlElement("regenerateTemplate")]
        public bool RegenerateTemplate { get; set; }
        [XmlElement("retryCount")]
        public int RetryCount { get; set; }
        [XmlElement("rotate")]
        public bool Rotate { get; set; }
        [XmlElement("threadCount")]
        public int ThreadCount { get; set; }
        [XmlElement("validateResponse")]
        public bool ValidateResponse { get; set; }
    }
}
