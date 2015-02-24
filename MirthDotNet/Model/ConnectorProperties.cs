using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class ConnectorProperties
    {
        [XmlElement("listenerConnectorProperties")]
        public ListenerConnectorProperties ListenerConnectorProperties { get; set; }
        [XmlElement("sourceConnectorProperties")]
        public SourceConnectorProperties SourceConnectorProperties { get; set; }
        [XmlElement("destinationConnectorProperties")]
        public DestinationConnectorProperties DestinationConnectorProperties { get; set; }
        [XmlElement("transmissionModeProperties")]
        public TransmissionModeProperties TransmissionModeProperties { get; set; }

        // START "Web Service Listener" Properties
        /// <summary>
        /// Applicable for Web Service Listener
        /// </summary>
        [XmlElement("serviceName")]
        public string ServiceName { get; set; }
        /// <summary>
        /// Applicable for Web Service Listener
        /// </summary>
        [XmlElement("className")]
        public string ClassName { get; set; }
        // END "Web Service Listener" Properties

        // START "TCP Listener" Properties
        /// <summary>
        /// Applicable for TCP Listener
        /// </summary>
        [XmlElement("receiveTimeout")]
        public int receiveTimeout { get; set; }
        /// <summary>
        /// Applicable for TCP Listener
        /// </summary>
        [XmlElement("bufferSize")]
        public int BufferSize { get; set; }
        [XmlElement("keepConnectionOpen")]
        public bool KeepConnectionOpen { get; set; }
        [XmlElement("maxConnections")]
        public int MaxConnections { get; set; }
        // END "TCP Listener" Properties
    }
}
