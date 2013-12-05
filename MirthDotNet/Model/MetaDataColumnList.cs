using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [XmlRoot("list")]
    public class MetaDataColumnList
    {
        [XmlElement("metaDataColumn")]
        public List<MetaDataColumn> Items { get; set; }
    }
}
