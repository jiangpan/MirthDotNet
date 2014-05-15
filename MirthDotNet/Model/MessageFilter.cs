using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("messageFilter")]
    public class MessageFilter
    {
        public MessageFilter()
        {
            this.ContentSearchElements = new List<ContentSearchElement>()
            {
                //new ContentSearchElement() { ContentCode = 1 },
                //new ContentSearchElement() { ContentCode = 2 },
                //new ContentSearchElement() { ContentCode = 3 },
                //new ContentSearchElement() { ContentCode = 4 },
                //new ContentSearchElement() { ContentCode = 5 },
                //new ContentSearchElement() { ContentCode = 6 },
                //new ContentSearchElement() { ContentCode = 7 },
                //new ContentSearchElement() { ContentCode = 8 },
            };
            this.TextSearchMetaDataColumns = new List<string>()
            {
                "SOURCE",
                "TYPE",
            };
        }

        [XmlElement("maxMessageId")]
        public long MaxMessageId { get; set; }
        [XmlElement("minMessageId")]
        public long? MinMessageId { get; set; }
        public bool ShouldSerializeMinMessageId() { return MinMessageId.HasValue; }

        [XmlElement("attachment")]
        public bool Attachment { get; set; }
        [XmlElement("error")]
        public bool Error { get; set; }

        [XmlElement("startDate")]
        public MirthDateTime startDate { get; set; }
        [XmlIgnore()]
        public DateTime StartDate
        {
            set
            {
                startDate = new MirthDateTime();
                startDate.DateTime = value;
            }
        }
        [XmlElement("endDate")]
        public MirthDateTime endDate { get; set; }
        [XmlIgnore()]
        public DateTime EndDate
        {
            set
            {
                endDate = new MirthDateTime();
                endDate.DateTime = value;
            }
        }

        [XmlArray("statuses"), XmlArrayItem("com.mirth.connect.donkey.model.message.Status")]
        public List<string> Statuses;

        [XmlArray("metaDataSearch"), XmlArrayItem("metaDataSearchCriteria")]
        public List<MetaDataSearchCriteria> MetaDataSearch { get; set; }

        [XmlElement("textSearch")]
        public string TextSearch { get; set; }

        [XmlArray("contentSearch"), XmlArrayItem("com.mirth.connect.model.filters.elements.ContentSearchElement")]
        public List<ContentSearchElement> ContentSearchElements { get; set; }
        public bool ShouldSerializeContentSearchElements() { return !string.IsNullOrWhiteSpace(TextSearch); }

        [XmlRoot("com.mirth.connect.model.filters.elements.ContentSearchElement")]
        public class ContentSearchElement
        {
            public ContentSearchElement()
            {
                Searches = string.Empty;
            }

            [XmlElement("contentCode")]
            public int ContentCode { get; set; }
            [XmlElement("searches")]
            public string Searches { get; set; }
        }

        [XmlArray("textSearchMetaDataColumns"), XmlArrayItem("string")]
        public List<string> TextSearchMetaDataColumns { get; set; }
        public bool ShouldSerializeTextSearchMetaDataColumns() { return !string.IsNullOrWhiteSpace(TextSearch); }
    }
}
