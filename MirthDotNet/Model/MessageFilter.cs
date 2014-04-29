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
        [XmlElement("maxMessageId")]
        public long MaxMessageId { get; set; }
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

        [XmlElement("messageIdUpper")]
        public long? MessageIdUpper { get; set; }
        public bool ShouldSerializeMessageIdUpper() { return MessageIdUpper.HasValue; }
        [XmlElement("messageIdLower")]
        public long? MessageIdLower { get; set; }
        public bool ShouldSerializeMessageIdLower() { return MessageIdLower.HasValue; }

        /*
         * 
  <textSearch>asdf</textSearch>
  <contentSearch>
    <com.mirth.connect.model.filters.elements.ContentSearchElement>
      <contentCode>1</contentCode>
      <searches/>
    </com.mirth.connect.model.filters.elements.ContentSearchElement>
    <com.mirth.connect.model.filters.elements.ContentSearchElement>
      <contentCode>2</contentCode>
      <searches/>
    </com.mirth.connect.model.filters.elements.ContentSearchElement>
    <com.mirth.connect.model.filters.elements.ContentSearchElement>
      <contentCode>3</contentCode>
      <searches/>
    </com.mirth.connect.model.filters.elements.ContentSearchElement>
    <com.mirth.connect.model.filters.elements.ContentSearchElement>
      <contentCode>4</contentCode>
      <searches/>
    </com.mirth.connect.model.filters.elements.ContentSearchElement>
    <com.mirth.connect.model.filters.elements.ContentSearchElement>
      <contentCode>5</contentCode>
      <searches/>
    </com.mirth.connect.model.filters.elements.ContentSearchElement>
    <com.mirth.connect.model.filters.elements.ContentSearchElement>
      <contentCode>6</contentCode>
      <searches/>
    </com.mirth.connect.model.filters.elements.ContentSearchElement>
    <com.mirth.connect.model.filters.elements.ContentSearchElement>
      <contentCode>7</contentCode>
      <searches/>
    </com.mirth.connect.model.filters.elements.ContentSearchElement>
    <com.mirth.connect.model.filters.elements.ContentSearchElement>
      <contentCode>8</contentCode>
      <searches/>
    </com.mirth.connect.model.filters.elements.ContentSearchElement>
  </contentSearch>
  <textSearchMetaDataColumns>
    <string>SOURCE</string>
    <string>TYPE</string>
    <string>PATIENT_ID</string>
    <string>PATIENT_LASTNAME</string>
    <string>ENCOUNTER_ID</string>
  </textSearchMetaDataColumns>
         */
    }
}
