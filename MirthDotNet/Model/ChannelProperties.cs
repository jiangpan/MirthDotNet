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
        public bool StoreAttachments { get; set; }
        [XmlElement("removeContentOnCompletion")]
        public bool RemoveContentOnCompletion { get; set; }
        [XmlElement("removeAttachmentsOnCompletion")]
        public bool RemoveAttachmentsOnCompletion { get; set; }
        [XmlElement("encryptData")]
        public bool EncryptData { get; set; }

        [XmlElement("pruneMetaDataDays")]
        public int PruneMetaDataDays { get; set; }
        [XmlElement("pruneContentDays")]
        public int? PruneContentDays { get; set; }
        [XmlElement("archiveEnabled")]
        public bool ArchiveEnabled { get; set; }

        [XmlElement("metaDataColumns")]
        public MetaDataColumnList MetaDataColumns { get; set; }

        [XmlArray("tags"), XmlArrayItem("string")]
        public List<string> Tags { get; set; }
    }
}
