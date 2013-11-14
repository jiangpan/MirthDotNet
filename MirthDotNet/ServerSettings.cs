using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet
{
    [Serializable]
    [XmlRoot("serverSettings")]
    public class ServerSettings
    {
        public bool clearGlobalMap { get; set; }
        public int queueBufferSize { get; set; }
        /// <summary>
        /// deprecated in Mirth 3.0
        /// </summary>
        public int maxQueueSize { get; set; }
        public List<MetaDataColumn> defaultMetaDataColumns { get; set; }

        // SMTP
        public string smtpHost { get; set; }
        public string smtpPort { get; set; }
        public int smtpTimeout { get; set; }
        public string smtpFrom { get; set; }
        public string smtpSecure { get; set; }
        public bool smtpAuth { get; set; }
        public string smtpUsername { get; set; }
        public string smtpPassword { get; set; }
    }
}
