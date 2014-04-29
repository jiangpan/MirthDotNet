using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class ChannelProperties
    {
        [XmlElement("initialState")]
        public DeployedState InitialState { get; set; }
        [XmlElement("clearGlobalChannelMap")]
        public string ClearGlobalChannelMap { get; set; }

        [XmlElement("messageStorageMode")]
        public string MessageStorageMode { get; set; }
        [XmlElement("storeAttachments")]
        public string StoreAttachments { get; set; }
        [XmlElement("removeContentOnCompletion")]
        public string RemoveContentOnCompletion { get; set; }
        [XmlElement("removeAttachmentsOnCompletion")]
        public string RemoveAttachmentsOnCompletion { get; set; }
        [XmlElement("encryptData")]
        public string EncryptData { get; set; }

        [XmlElement("pruneMetaDataDays")]
        public string PruneMetaDataDays { get; set; }
        [XmlElement("archiveEnabled")]
        public string ArchiveEnabled { get; set; }

        [XmlElement("metaDataColumns")]
        public MetaDataColumnList MetaDataColumns { get; set; }

        [XmlArray("tags"), XmlArrayItem("string")]
        public List<string> Tags { get; set; }
    }
}
