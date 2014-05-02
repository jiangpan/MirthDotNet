using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MirthDotNet.Plugins
{
    public class ChannelHistory
    {
        public ChannelHistory(Client client)
        {
            this.client = client;
        }

        private readonly Client client;

        private static readonly string LIST_SNAPSHOT_FOR_CHANNEL = "listSnapshotForChannel";
        private static readonly string CHANNELHISTORY_SERVICE_PLUGINPOINT = "Channel History";

        public ChannelHistorySnapshotList ListSnapshotForChannel(string channelId)
        {
            var channelIdParam = "<string>" + channelId.Trim() + "</string>";
            return this.client.InvokePluginMethod<ChannelHistorySnapshotList>(CHANNELHISTORY_SERVICE_PLUGINPOINT, LIST_SNAPSHOT_FOR_CHANNEL, channelIdParam);
        }
    }
}
