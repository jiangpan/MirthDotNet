using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MirthDotNet.Model
{
    public class FlatMessageRow
    {
        public long MessageId { get; set; }
        public int MetaDataId { get; set; }
        public int ChainId { get; set; }
        public int OrderId { get; set; }
        public string ConnectorName { get; set; }

        public string ServerId { get; set; }
        public string ChannelId { get; set; }
        public bool Processed { get; set; }

        public long OriginalMessageId { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime? OriginalReceivedDate { get; set; }
        public Message.MessageStatusEnum Status { get; set; }

        public int SendAttempts { get; set; }
        public DateTime? SendDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public int ErrorCode { get; set; }

        public Dictionary<string, string> MetaData { get; set; }
    }
}
