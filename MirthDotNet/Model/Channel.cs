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

        public ReadOnlyCollection<Connector> GetAllEnabledChannels()
        {
            var list =new List<Connector>();
            list.Add(SourceConnector);
            list.AddRange(DestinationConnectors.Where(x => x.Enabled));
            return list.AsReadOnly();
        }

        //[XmlElement("pruneMetaDataDays")]
        //public int PruneMetaDataDays { get; set; }
        //[XmlElement("archiveEnabled")]
        //public bool ArchiveEnabled { get; set; }
        /*
         <id>352f2896-3292-48ec-85d6-d05b7a45b75c</id>
    <nextMetaDataId>2</nextMetaDataId>
    <name>BaptistPracticePlus - Test - Inbound</name>
    <description>Port 9241</description>
    <enabled>true</enabled>
    <lastModified>
      <time>1392244357134</time>
      <timezone>America/New_York</timezone>
    </lastModified>
    <revision>6</revision>
         <properties version="3.0.1">
      <clearGlobalChannelMap>true</clearGlobalChannelMap>
      <messageStorageMode>PRODUCTION</messageStorageMode>
      <encryptData>false</encryptData>
      <removeContentOnCompletion>false</removeContentOnCompletion>
      <removeAttachmentsOnCompletion>false</removeAttachmentsOnCompletion>
      <initialState>STARTED</initialState>
      <storeAttachments>false</storeAttachments>
      <tags class="linked-hash-set">
        <string>Practice Plus</string>
        <string>Inbound</string>
        <string>Test</string>
      </tags>
      <metaDataColumns>
        <metaDataColumn>
          <name>SOURCE</name>
          <type>STRING</type>
          <mappingName>mirth_source</mappingName>
        </metaDataColumn>
        <metaDataColumn>
          <name>TYPE</name>
          <type>STRING</type>
          <mappingName>mirth_type</mappingName>
        </metaDataColumn>
      </metaDataColumns>
      <attachmentProperties>
        <type>None</type>
        <properties/>
      </attachmentProperties>
      <pruneMetaDataDays>7</pruneMetaDataDays>
      <archiveEnabled>true</archiveEnabled>
    </properties>
         */
    }
}
