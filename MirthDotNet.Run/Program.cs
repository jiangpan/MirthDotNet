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
        public const string ClientUrl = "https://127.0.0.1:8443";
        public const string ClientUsername = "admin";
        public const string ClientPassword = "admin";


        public static void Main(string[] args)
        {
            FindFailedToDeployConnectors();
            PurgeERRORMessages();
        }

        public static string MaxOrPad(this string input, int totalWidth)
        {
            if (input.Length > totalWidth)
            {
                return input.Substring(0, totalWidth - 3) + "...";
            }
            return input.PadRight(totalWidth);
        }

        public static void FindFailedToDeployConnectors()
        {
            var client = new Client(ClientUrl, timeout: int.MaxValue);
            var loginStatus = client.Login(ClientUsername, ClientPassword, "0.0.0");
            var channelStatusList = client.GetChannelStatusList().DashboardStatuses;
            foreach (var item in channelStatusList.OrderBy(x => x.Name))
            {
                Console.Write("{0} deployed with {1} connectors. ", item.Name.MaxOrPad(30), item.ChildStatuses.DashboardStatuses.Count);
                var channelId = item.ChannelId;
                var channel = client.GetChannels(channelId).Channels.Single();
                var connectors = channel.GetAllEnabledConnectors();
                if (connectors.Count != item.ChildStatuses.DashboardStatuses.Count)
                {
                    Console.Write("WARNING: Found {0} configured connectors!", connectors.Count);
                    Console.Error.Write("WARNING: Found {0} configured connectors!", connectors.Count);
                }
                Console.WriteLine();
            }
            client.Logout();
        }

        public static void PurgeERRORMessages()
        {
            var client = new Client(ClientUrl, timeout: int.MaxValue);
            var loginStatus = client.Login(ClientUsername, ClientPassword, "0.0.0");
            var channelSummaryList = client.GetChannelSummary();

            Console.WriteLine("Found " + channelSummaryList.Channels.Count + " channels...");
            for (int i = 0; i < channelSummaryList.Channels.Count; i++)
            {
                try
                {
                    var channelId = channelSummaryList.Channels[i].GetChannelId();
                    Console.Write((i) + " ");
                    var maxMessageId = client.GetMaxMessageId(channelId);
                    if (maxMessageId == 0)
                    {
                        Console.WriteLine();
                        continue;
                    }
                    var filter = new MessageFilter()
                    {
                        MaxMessageId = maxMessageId,
                        Statuses = new List<string>() { "ERROR" },
                        EndDate = DateTime.Now.Date.AddDays(-7),
                    };
                    var messageCount = client.GetMessageCount(channelId, filter);
                    var channel = client.GetChannels(channelId).Channels.Single();
                    Console.Write("Found " + messageCount + " messages for " + channel.Name + "...");
                    if (messageCount == 0)
                    {
                        Console.WriteLine();
                        continue;
                    }
                    var sw = Stopwatch.StartNew();
                    client.RemoveMessages(channelId, filter);
                    sw.Stop();
                    Console.WriteLine(" Deleted in " + sw.Elapsed.TotalSeconds.ToString("N2") + " sec.");
                }
                catch (Exception e)
                {
                    Console.Write(" ERROR: " + e.Message);
                }
            }

            client.Logout();
        }
    }
}
