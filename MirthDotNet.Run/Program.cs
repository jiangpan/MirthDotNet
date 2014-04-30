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
            ListChannels();
            FindFailedToDeployConnectors();
            PurgeERRORMessages();
        }

        public static void TestMessageSearch()
        {
            var client = new Client(ClientUrl, timeout: int.MaxValue);
            try
            {
                var sw = Stopwatch.StartNew();
                var loginStatus = client.Login(ClientUsername, ClientPassword, "0.0.0");
                var channel = client.GetChannels("d24f9ca7-d696-4ffd-b86e-484669213fa8").Channels[0];
                Console.WriteLine("Loaded Channel [{0}] in {1}ms ", channel.Name, sw.Elapsed.TotalMilliseconds.ToString("N2"));
                Console.WriteLine("Found {0} metadata columns: {1}", channel.Properties.MetaDataColumns.Items.Count, string.Join(",", channel.Properties.MetaDataColumns.Items.Select(x => x.Name).ToArray()));
                sw.Restart();
                var maxMessageId = client.GetMaxMessageId(channel.Id);
                var filter = new MessageFilter()
                {
                    MaxMessageId = maxMessageId,
                    //Statuses = new List<string>() { "ERROR" },
                    //EndDate = DateTime.Now.Date.AddDays(-7),
                    MetaDataSearch = new List<MetaDataSearchCriteria>
                    {
                        new MetaDataSearchCriteria
                        {
                            ColumnName = "PATIENT_ID",
                            Value = new MetaDataSearchCriteriaValue("00556249"),
                            Operator = MetaDataSearchOperator.STARTS_WITH,
                            IgnoreCase = "true",
                        },
                    },
                    MinMessageId = 896930,
                };
                var messageCount = client.GetMessageCount(channel.Id, filter);
                Console.WriteLine("Counted {0} messages in {1}ms", messageCount, sw.Elapsed.TotalMilliseconds.ToString("N2"));
                sw.Restart();
                var messages_nocontent = client.GetMessages(channel.Id, filter, false, 0, 51);
                Console.WriteLine("Loaded {0} messages in {1}ms", messages_nocontent.Messages.Count, sw.Elapsed.TotalMilliseconds.ToString("N2"));
                var messages_rows = messages_nocontent.Messages.SelectMany(x => x.AsFlatMessageRows()).ToArray();
            }
            finally
            {
                client.Logout();
            }
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

        public static void ListChannels()
        {
            var client = new Client(ClientUrl, timeout: int.MaxValue);
            var loginStatus = client.Login(ClientUsername, ClientPassword, "0.0.0");
            var channelSummaryList = client.GetChannelSummary();

            Console.WriteLine("Found " + channelSummaryList.Channels.Count + " channels...");
            Console.WriteLine("Index^Channel Name^Description^Max Message Id^Revision^Enabled^Channel Id");
            for (int i = 0; i < channelSummaryList.Channels.Count; i++)
            {
                try
                {
                    var channelId = channelSummaryList.Channels[i].GetChannelId();
                    var maxMessageId = client.GetMaxMessageId(channelId);
                    var channel = client.GetChannels(channelId).Channels.Single();
                    Console.WriteLine(string.Format(@"{0}^{1}^{2}^{3}^{4}^{5}^{6}", i, channel.Name, channel.Description.Replace("\n", " "), maxMessageId, channel.Revision, channel.Enabled, channelId));
                }
                catch (Exception e)
                {
                    Console.WriteLine(" ERROR: " + e.Message);
                }
            }

            client.Logout();
        }
    }
}
