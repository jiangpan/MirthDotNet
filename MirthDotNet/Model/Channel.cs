using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("channel")]
    public class Channel
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("enabled")]
        public bool Enabled { get; set; }
        [XmlElement("revision")]
        public int Revision { get; set; }
        [XmlElement("lastModified")]
        public MirthDateTime LastModified { get; set; }
        [XmlElement("sourceConnector")]
        public Connector SourceConnector { get; set; }
        [XmlArray("destinationConnectors"), XmlArrayItem("connector")]
        public Connector[] DestinationConnectors { get; set; }

        [XmlElement("properties")]
        public ChannelProperties Properties { get; set; }

        public ReadOnlyCollection<Connector> GetAllEnabledConnectors()
        {
            var list =new List<Connector>();
            list.Add(SourceConnector);
            list.AddRange(DestinationConnectors.Where(x => x.Enabled));
            return list.AsReadOnly();
        }
    }
}
