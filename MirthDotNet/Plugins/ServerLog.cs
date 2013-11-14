using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MirthDotNet.Model;

namespace MirthDotNet.Plugins
{
    public class ServerLog
    {
        public ServerLog(Client client)
        {
            this.client = client;
        }

        private readonly Client client;

        private static readonly string GET_SERVER_LOGS = "getMirthServerLogs";
        private static readonly string REMOVE_SESSIONID = "removeSessionId";
        private static readonly string SERVER_PLUGIN_NAME = "Server Log";

        public MirthLinkedList GetServerLogs()
        {
            return this.client.InvokePluginMethod < MirthLinkedList>(SERVER_PLUGIN_NAME, GET_SERVER_LOGS, null);
        }

        public void RemoveSessionid()
        {
            this.client.InvokePluginMethod(SERVER_PLUGIN_NAME, REMOVE_SESSIONID, null);
        }
    }
}
