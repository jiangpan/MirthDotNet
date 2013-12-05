using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MirthDotNet.Model
{
    public class Message
    {
        public enum MessageStatusEnum
        {
            RECEIVED, FILTERED, TRANSFORMED, SENT, QUEUED, ERROR, PENDING
        }

        [XmlElement("messageId")]
        public long MessageId { get; set; }
        [XmlElement("serverId")]
        public string ServerId { get; set; }
        [XmlElement("channelId")]
        public string ChannelId { get; set; }
        [XmlElement("receivedDate")]
        public MirthDateTime ReceivedDate { get; set; }
        [XmlElement("processed")]
        public bool Processed { get; set; }
        [XmlElement("connectorMessages")]
        public MirthLinkedHashMap<ConnectorMessagesLinkedHashMapItem> ConnectorMessages { get; set; }

        public class ConnectorMessagesLinkedHashMapItem
        {
            [XmlElement("int")]
            public int MetaDataId { get; set; }
            [XmlElement("connectorMessage")]
            public ConnectorMessage ConnectorMessage { get; set; }
        }

        public class ConnectorMessage
        {
            [XmlElement("messageId")]
            public long MessageId { get; set; }
            [XmlElement("originalId")]
            public long OriginalMessageId { get; set; } // if re-reprocessed
            [XmlElement("metaDataId")]
            public int MetaDataId { get; set; }
            [XmlElement("connectorName")]
            public string ConnectorName { get; set; }
            [XmlElement("serverId")]
            public string ServerId { get; set; }
            [XmlElement("channelId")]
            public string ChannelId { get; set; }
            [XmlElement("receivedDate")]
            public MirthDateTime ReceivedDate { get; set; }
            [XmlElement("status")]
            public MessageStatusEnum Status { get; set; }

            //<metaDataMap/>
          //  <metaDataMap>
          //  <entry>
          //    <string>MESSAGE_ID</string>
          //    <big-decimal>2</big-decimal>
          //  </entry>
          //  <entry>
          //    <string>SOURCE</string>
          //    <null/>
          //  </entry>
          //  <entry>
          //    <string>VARIABLE1</string>
          //    <string>2</string>
          //  </entry>
          //  <entry>
          //    <string>METADATA_ID</string>
          //    <big-decimal>1</big-decimal>
          //  </entry>
          //  <entry>
          //    <string>TYPE</string>
          //    <null/>
          //  </entry>
          //</metaDataMap>

            [XmlElement("ErrorCode")]
            public int ErrorCode { get; set; }
            [XmlElement("sendAttempts")]
            public int SendAttempts { get; set; }
            [XmlElement("responseDate")]
            public MirthDateTime ResponseDate { get; set; }
            [XmlElement("chainId")]
            public int ChainId { get; set; }
            [XmlElement("orderId")]
            public int OrderId { get; set; }
        }
    }
}
