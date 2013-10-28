using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MirthDotNet
{
    /// <remarks>
    /// This code is ported from: https://svn.mirthcorp.com/connect/trunk/server/src/com/mirth/connect/client/core/ServerConnection.java
    /// </remarks>
    public class ServerConnection
    {
        public ServerConnection(string address)
            : this(address, 30 * 1000)
        {
        }

        public ServerConnection(string address, int timeout)
        {
            this.address = address;
            this.timeout = timeout;

            this.webClient = new HttpClient();
            this.webClient.BaseAddress = new Uri(address);
        }

        private readonly string address;
        private readonly int timeout;
        private readonly HttpClient webClient;

        public string ExecutPostMethod(string servletName, IEnumerable<KeyValuePair<string, string>> data)
        {
            var task = ExecutPostMethodAsync(servletName, data);
            if (task.Wait(timeout))
            {
                return task.Result.Trim();
            }
            else
            {
                throw new TimeoutException("ExecutPostMethodAsync Timeout");
            }
        }

        public async Task<string> ExecutPostMethodAsync(string servletName, IEnumerable<KeyValuePair<string, string>> data)
        {
            var content = new FormUrlEncodedContent(data);
            var result = await this.webClient.PostAsync(servletName, content);
            return await result.Content.ReadAsStringAsync();

            //var response = this.webClient.PostAsync(servletName, "POST", data);
            //return Encoding.UTF8.GetString(response).Trim();
        }
    }
}
