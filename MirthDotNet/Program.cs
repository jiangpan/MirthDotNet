using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MirthDotNet
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // This will disable SSL certificate validation but useful for dev environments
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var client = new Client("https://sit-mirth.clearwaveinc.com:8443");
            var loginStatus = client.Login("admin", "admin", "0.0.0");
            var serverId = client.GetServerId();
            var timeZone = client.GetServerTimezone();
            var status = client.GetStatus();
            var buildDate = client.GetBuildDate();
            var version = client.GetVersion();
            var channelStatusList = client.GetChannelStatusList();
        }
    }
}
