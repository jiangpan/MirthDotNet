using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    [Serializable]
    [XmlRoot("object-array")]
    public class DashboardConnectorState
    {
        [XmlElement("awt-color")]
        public DashboardConnectorStateColor Color { get; set; }

        [XmlElement("string")]
        public string State { get; set; }

        public class DashboardConnectorStateColor
        {
            public int red;
            public int green;
            public int blue;
            public int alpha;
        }
    }
}
