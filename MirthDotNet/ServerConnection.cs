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
        public const int DefaultTimeout = (30 * 1000);

        public ServerConnection(string address, int timeout = DefaultTimeout)
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
            var result = PostAsync(servletName, data);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.StatusCode.ToString() + " " + ReadContentFromResult(result));
                //what?
            }
            return ReadContentFromResult(result);
        }

        private HttpResponseMessage PostAsync(string servletName, IEnumerable<KeyValuePair<string, string>> data)
        {
            var content = new FormUrlEncodedContent(data);
            var task = this.webClient.PostAsync(servletName, content);
            try
            {
                if (task.Wait(timeout))
                {
                    return task.Result;
                }
                else
                {
                    throw new TimeoutException("PostAsync Timeout");
                }
            }
            catch (AggregateException e)
            {
                if (e.InnerExceptions.Count == 1)
                {
                    var ex = e.InnerException;
                    ex.PreserveStackTrace();
                    throw ex;
                }
                throw;
            }
        }

        private string ReadContentFromResult(HttpResponseMessage result)
        {
            var task = result.Content.ReadAsStringAsync();
            try
            {
                if (task.Wait(timeout))
                {
                    return task.Result;
                }
                else
                {
                    throw new TimeoutException("ReadContentFromResult Timeout");
                }
            }
            catch (AggregateException e)
            {
                if (e.InnerExceptions.Count == 1)
                {
                    var ex = e.InnerException;
                    ex.PreserveStackTrace();
                    throw ex;
                }
                throw;
            }
        }
    }
}
