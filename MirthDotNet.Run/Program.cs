using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using MirthDotNet.Model;

namespace MirthDotNet
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // This will disable SSL certificate validation but useful for dev environments
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var channelId = "d24f9ca7-d696-4ffd-b86e-484669213fa8";
            var maxMessageId = client.GetMaxMessageId(channelId);
            var filter = new MessageFilter()
            {
                MaxMessageId = maxMessageId,
                Statuses = new List<string>() { "ERROR" },
                EndDate = new DateTime(2014, 02, 05),
            };
            var messages = client.GetMessages(channelId, filter, includeContent: false, offset: 0, limit: 10);
            var messageCount = client.GetMessageCount(channelId, filter);
            var client = new Client("https://localhost:8443");
            var loginStatus = client.Login("admin", "admin", "0.0.0");
            //var serverId = client.GetServerId();
            //var timeZone = client.GetServerTimezone();
            //var status = client.GetStatus();
            //var buildDate = client.GetBuildDate();
            //var version = client.GetVersion();
            //var tags = client.GetChannelTags();
            var channelStatusList = client.GetChannelStatusList().DashboardStatuses.ToArray();
            var chan = channelStatusList.Where(x => x.Name.ToLower().Contains("blah")).Single();
            //var serverSettings = client.GetServerSettings();
            //var codeTemplates = client.GetCodeTemplate();
            //var stats = channelStatusList.Select(x => client.GetStatistics(x.ChannelId)).ToArray();
            //var log = client.ServerLog.GetServerLogs();
            //// var connectionLog = client.DashboardConnectorStatus.GetConnectionInfoLogs();
            //var connectionLog_channel = client.DashboardConnectorStatus.GetConnectionInfoLogs("POC - Inbound NEW");
            var channelId = chan.ChannelId;
            var connectorNames = client.GetConnectorNames(channelId);
            var metadatacolumns = client.GetMetaDataColumns(channelId);
            var maxmessageid = client.GetMaxMessageId(channelId);
            var messages = client.GetMessages(channelId, new MessageFilter()
            {
                MaxMessageId = maxmessageid,
            });
            var states = client.DashboardConnectorStatus.GetStates();
            var _states = states.MirthMapItem.OrderBy(x => x.Key).ToArray();
            var channelsDeployed = client.DashboardConnectorStatus.ChannelsDeployed();
            client.Logout();
        }
    }
}
