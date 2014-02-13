using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MirthDotNet.Model;

namespace MirthDotNet
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var client = new Client("https://127.0.0.1:8443");
            var loginStatus = client.Login("admin", "admin", "0.0.0");
            var channelStatusList = client.GetChannelStatusList().DashboardStatuses.ToArray();

            foreach (var channel in channelStatusList)
            {
                var channelId = channel.ChannelId;
                var maxMessageId = client.GetMaxMessageId(channelId);
                var filter = new MessageFilter()
                {
                    MaxMessageId = maxMessageId,
                    Statuses = new List<string>() { "ERROR" },
                    EndDate = DateTime.Now.Date.AddDays(-7),
                };
                //var messages = client.GetMessages(channelId, filter, includeContent: false, offset: 0, limit: 10);
                var messageCount = client.GetMessageCount(channelId, filter);
                var sw = Stopwatch.StartNew();
                //client.RemoveMessages(channelId, filter);
                sw.Stop();
                Console.WriteLine(channel.Name + " | " + messageCount + " | " + sw.Elapsed.TotalMilliseconds);
            }
            client.Logout();
        }
    }
}
