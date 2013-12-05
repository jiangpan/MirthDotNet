using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MirthDotNet.Model;

namespace MirthDotNet.Plugins
{
    public class DashboardConnectorStatus
    {
        public DashboardConnectorStatus(Client client)
        {
            this.client = client;
        }

        private readonly Client client;

        private static readonly string GET_STATES = "getStates";
        private static readonly string GET_CONNECTION_INFO_LOGS = "getConnectionInfoLogs";
        private static readonly string CHANNELS_DEPLOYED = "channelsDeployed";
        private static readonly string REMOVE_SESSIONID = "removeSessionId";
        private static readonly string DASHBOARD_SERVICE_PLUGINPOINT = "Dashboard Connector Service";

        public MirthMap<MirthMapDashboardConnectorStateItem> GetStates()
        {
            return this.client.InvokePluginMethod<MirthMap<MirthMapDashboardConnectorStateItem>>(DASHBOARD_SERVICE_PLUGINPOINT, GET_STATES, null);
        }

        public bool ChannelsDeployed()
        {
            var r = this.client.InvokePluginMethod(DASHBOARD_SERVICE_PLUGINPOINT, CHANNELS_DEPLOYED, null);
            // TODO: this is kind of hacky
            r = r.Replace("<boolean>", "");
            r = r.Replace("</boolean>", "");
            return bool.Parse(r);
        }

        public MirthLinkedList GetConnectionInfoLogs(string channelId = null)
        {
            if (!string.IsNullOrWhiteSpace(channelId))
            {
                channelId = "<string>" + channelId.Trim() + "</string>";
            }
            return this.client.InvokePluginMethod<MirthLinkedList>(DASHBOARD_SERVICE_PLUGINPOINT, GET_CONNECTION_INFO_LOGS, channelId);
        }

        public void RemoveSessionid()
        {
            this.client.InvokePluginMethod(DASHBOARD_SERVICE_PLUGINPOINT, REMOVE_SESSIONID, null);
        }
    }
}
