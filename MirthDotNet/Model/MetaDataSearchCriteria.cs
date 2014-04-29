using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    public class MetaDataSearchCriteria
    {
        public MetaDataSearchCriteria()
        {
            Operator = MetaDataSearchOperator.STARTS_WITH;
            IgnoreCase = "true";
        }
        [XmlElement("columnName")]
        public string ColumnName { get; set; }
        [XmlElement("operator")]
        public MetaDataSearchOperator Operator { get; set; }
        [XmlElement("value")]
        public MetaDataSearchCriteriaValue Value { get; set; }
        [XmlElement("ignoreCase")]
        public string IgnoreCase { get; set; }
    }

    public class MetaDataSearchCriteriaValue
    {
        public MetaDataSearchCriteriaValue()
        {
            Class = "string";
        }

        public MetaDataSearchCriteriaValue(string value)
            : this()
        {
            this.Value = value;
        }

        [XmlAttribute("class")]
        public string Class { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
}
