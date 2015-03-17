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

        [XmlAttribute("class")]
        public string Class { get; set; }

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
        public int ReceiveTimeout { get; set; }
        /// <summary>
        /// Applicable for TCP Listener
        /// </summary>
        [XmlElement("bufferSize")]
        public string BufferSize { get; set; }
        [XmlElement("keepConnectionOpen")]
        public bool KeepConnectionOpen { get; set; }
        [XmlElement("maxConnections")]
        public int MaxConnections { get; set; }
        // END "TCP Listener" Properties

        [XmlElement("wsdlUrl")]
        public string SOAPWSDLUrl { get; set; }
        [XmlElement("service")]
        public string SOAPService { get; set; }
        [XmlElement("port")]
        public string SOAPPort { get; set; }
        [XmlElement("locationURI")]
        public string SOAPLocationURI { get; set; }
        [XmlElement("socketTimeout")]
        public string SOAPSocketTimeout { get; set; }
        [XmlElement("oneWay")]
        public bool SOAPIsOneWayInvocation { get; set; }
        [XmlElement("operation")]
        public string SOAPOperation { get; set; }
        [XmlElement("soapAction")]
        public string SOAPAction { get; set; }
        [XmlElement("envelope")]
        public string SOAPEnvelope { get; set; }


        [XmlElement("remoteAddress")]
        public string RemoteAddress { get; set; }
        [XmlElement("remotePort")]
        public string RemotePort { get; set; }
        [XmlElement("sendTimeout")]
        public string SendTimeout { get; set; }
        //[XmlElement("bufferSize")]
        //public string BufferSize { get; set; }
        //[XmlElement("keepConnectionOpen")]
        //public bool KeepConnectionOpen { get; set; }
        [XmlElement("checkRemoteHost")]
        public bool CheckRemoteHost { get; set; }
        [XmlElement("responseTimeout")]
        public string ResponseTimeout { get; set; }
        [XmlElement("ignoreResponse")]
        public bool IgnoreResponse { get; set; }
        [XmlElement("queueOnResponseTimeout")]
        public bool QueueOnResponseTimeout { get; set; }
        [XmlElement("dataTypeBinary")]
        public bool DataTypeBinary { get; set; }
        [XmlElement("charsetEncoding")]
        public string CharsetEncoding { get; set; }
        [XmlElement("template")]
        public string Template { get; set; }
    }
}
