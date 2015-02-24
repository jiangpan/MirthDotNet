using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirthDotNet.Model
{
    public class ChannelCache
    {
        public Channel GetChannel(string id, Client client)
        {
            if (!cachedChannels.ContainsKey(id))
            {
                var channelList = client.GetChannels(id);
                if (channelList.Channels == null || channelList.Channels.Count == 0)
                {
                    return null;
                }
                SetChannels(channelList.Channels);
            }
            return cachedChannels[id];
        }

        public void SetChannels(IEnumerable<Channel> channels)
        {
            foreach (var channel in channels)
            {
                SetChannel(channel);
            }
        }

        public void SetChannel(Channel channel)
        {
            if (!cachedChannels.ContainsKey(channel.Id))
            {
                cachedChannels.Add(channel.Id, channel);
            }
            cachedChannels[channel.Id] = channel;

            if (!cachedHeaders.ContainsKey(channel.Id))
            {
                cachedHeaders.Add(channel.Id, new ChannelHeader());
            }
            cachedHeaders[channel.Id].Revision = channel.Revision;
        }

        private Dictionary<string, ChannelHeader> cachedHeaders = new Dictionary<string, ChannelHeader>(StringComparer.InvariantCultureIgnoreCase);
        private Dictionary<string, Channel> cachedChannels = new Dictionary<string, Channel>(StringComparer.InvariantCultureIgnoreCase);

        public void Refresh(Client client)
        {
            var channelSummary = client.GetChannelSummary(cachedHeaders.Select(x => new MirthMapStringChannelHeaderItem { Key = x.Key, ChannelHeader = x.Value }).ToArray());
            foreach (var channel in channelSummary.Channels)
            {
                if (channel.ChannelStatus.Channel != null)
                {
                    SetChannel(channel.ChannelStatus.Channel);
                }
                if (channel.ChannelStatus.DeployedDate != null)
                {
                    cachedHeaders[channel.ChannelId].deployedDate = channel.ChannelStatus.DeployedDate;
                }
            }
        }

        public void RefreshAll(Client client)
        {
            SetChannels(client.GetChannels().Channels);
        }
    }
}
