using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
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
            [XmlElement("originalReceivedDate")]
            public MirthDateTime OriginalReceivedDate { get; set; }
            [XmlElement("status")]
            public MessageStatusEnum Status { get; set; }

            [XmlArray("metaDataMap"), XmlArrayItem("entry")]
            public List<MessageMetaDataMap> MessageMetaDataMap { get; set; }

            [XmlElement("errorCode")]
            public int ErrorCode { get; set; }
            [XmlElement("sendAttempts")]
            public int SendAttempts { get; set; }
            [XmlElement("sendDate")]
            public MirthDateTime SendDate { get; set; }
            [XmlElement("responseDate")]
            public MirthDateTime ResponseDate { get; set; }
            [XmlElement("chainId")]
            public int ChainId { get; set; }
            [XmlElement("orderId")]
            public int OrderId { get; set; }
        }

        [Serializable]
        public class MessageMetaDataMap : IXmlSerializable
        {
            private List<string> strings = new List<string>();
            private List<decimal> numbers = new List<decimal>();

            public string Name
            {
                get
                {
                    return strings != null && strings.Count > 0 ? strings[0] : string.Empty;
                }
            }
            public string Value
            {
                get
                {
                    if (strings != null && strings.Count > 1)
                    {
                        return strings[1];
                    }
                    else if (numbers != null && numbers.Count > 0)
                    {
                        return numbers[0].ToString();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }

            public System.Xml.Schema.XmlSchema GetSchema()
            {
                return null;
            }

            public void ReadXml(System.Xml.XmlReader reader)
            {
                var localName = reader.Name;
                while (reader.Read())
                {
readagain:
                    if (reader.Name == "string" && reader.NodeType == XmlNodeType.Element)
                    {
                        strings.Add(reader.ReadElementString());
                        goto readagain;
                    }
                    if (reader.Name == "big-decimal" && reader.NodeType == XmlNodeType.Element)
                    {
                        numbers.Add(decimal.Parse(reader.ReadElementString()));
                        goto readagain;
                    }
                    if (reader.Name == localName && reader.NodeType == XmlNodeType.EndElement)
                    {
                        reader.Read();
                        break;
                    }
                }
            }

            public void WriteXml(System.Xml.XmlWriter writer)
            {
                throw new NotSupportedException();
            }

            public bool IsEmpty { get { return string.IsNullOrWhiteSpace(Name); } }
        }

        public List<FlatMessageRow> AsFlatMessageRows()
        {
            return this.ConnectorMessages.MirthHashMapItem.Select(m => new FlatMessageRow
            {
                MessageId = m.ConnectorMessage.MessageId,
                MetaDataId = m.ConnectorMessage.MetaDataId,
                ChainId = m.ConnectorMessage.ChainId,
                OrderId = m.ConnectorMessage.OrderId,
                ConnectorName = m.ConnectorMessage.ConnectorName,
                ServerId = m.ConnectorMessage.ServerId,
                ChannelId = m.ConnectorMessage.ChannelId,
                Processed = this.Processed,
                ReceivedDate = m.ConnectorMessage.ReceivedDate != null ? m.ConnectorMessage.ReceivedDate.DateTime : DateTime.MinValue,
                OriginalMessageId = m.ConnectorMessage.OriginalMessageId,
                OriginalReceivedDate = m.ConnectorMessage.OriginalReceivedDate != null ? m.ConnectorMessage.OriginalReceivedDate.DateTime : (DateTime?)null,
                Status = m.ConnectorMessage.Status,
                SendAttempts = m.ConnectorMessage.SendAttempts,
                ErrorCode = m.ConnectorMessage.ErrorCode,
                SendDate = m.ConnectorMessage.SendDate != null ? m.ConnectorMessage.SendDate.DateTime : (DateTime?)null,
                ResponseDate = m.ConnectorMessage.ResponseDate != null ? m.ConnectorMessage.ResponseDate.DateTime : (DateTime?)null,
                MetaData = m.ConnectorMessage.MessageMetaDataMap.Where(x => !x.IsEmpty).ToDictionary(x => x.Name, x => x.Value),
            }).ToList();
        }
    }
}
