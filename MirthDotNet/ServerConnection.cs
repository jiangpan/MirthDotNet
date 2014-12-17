using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Diagnostics;

namespace MirthDotNet
{
    /// <remarks>
    /// This code is ported from: https://svn.mirthcorp.com/connect/trunk/server/src/com/mirth/connect/client/core/ServerConnection.java
    /// </remarks>
    public class ServerConnection
    {
        public const int DefaultTimeout = (100 * 1000);
        private const string AuthCookieName = "JSESSIONID";

        public ServerConnection(string address, int timeout = DefaultTimeout)
        {
            this.address = address;
            this.timeout = timeout;

            this.baseAddress = new Uri(address);
        }

        private readonly string address;
        private readonly int timeout;
        private readonly Uri baseAddress;
        private readonly Stopwatch stopwatch = new Stopwatch();

        public Cookie AuthenticationCookie { get; private set; }

        public void SetNewAuthenticationCookie(string sessionId)
        {
            AuthenticationCookie = new Cookie(AuthCookieName, sessionId, "/", this.baseAddress.Host);
        }

        public void ClearAuthenticationCookie()
        {
            AuthenticationCookie = null;
        }

        public string ExecutPostMethod(string servletName, IEnumerable<KeyValuePair<string, string>> data)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            stopwatch.Start();
            try
            {
                var uri = new Uri(this.baseAddress, servletName);
                if (!MirthCertificateHandler.HostWhiteListContains(uri.Host))
                {
                    MirthCertificateHandler.AddHostToWhiteList(uri.Host);
                }
                var request = (HttpWebRequest)HttpWebRequest.Create(uri);
                request.Method = "POST";
                request.Timeout = this.timeout;
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Clearwave WebAccess";
                request.CookieContainer = new CookieContainer();
                if (AuthenticationCookie != null)
                {
                    request.CookieContainer.Add(AuthenticationCookie);
                }
                var postData = new StringBuilder();
                foreach (var item in data)
                {
                    postData.Append(item.Key + "=" + HttpUtility.UrlEncode(item.Value) + "&");
                }
                postData.Remove(postData.Length - 1, 1);
                var postDataBuffer = Encoding.UTF8.GetBytes(postData.ToString());
                request.ContentLength = postDataBuffer.Length;
                using (var dataStream = request.GetRequestStream())
                {
                    dataStream.Write(postDataBuffer, 0, postDataBuffer.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.StatusCode.ToString() + " " + ReadContentFromResult(response));
                    //what?
                }
                var cookies = response.Cookies;
                if (cookies[AuthCookieName] != null)
                {
                    this.AuthenticationCookie = cookies[AuthCookieName];
                }
                var resultString = ReadContentFromResult(response);
#if DEBUG
                Debug.WriteLine("Result: " + resultString);
#endif
                return resultString;
            }
            finally
            {
                stopwatch.Stop();
                var op = data.FirstOrDefault(x => x.Key.ToLower() == "op");
                Trace.WriteLine(string.Format("Executed OP [{0}] at {1} in {2}ms", op, servletName, stopwatch.Elapsed.TotalMilliseconds));
            }
        }

        private static string ReadContentFromResult(HttpWebResponse response)
        {
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
