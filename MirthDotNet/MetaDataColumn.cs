using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet
{
    [Serializable]
    [XmlRoot("metaDataColumn")]
    public class MetaDataColumn
    {
        public string name { get; set; }
        public MetaDataColumnType type { get; set; }
        public string mappingName { get; set; }
    }

    public enum MetaDataColumnType
    {
        STRING, NUMBER, BOOLEAN, TIMESTAMP
    }
}
