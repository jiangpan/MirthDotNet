using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MirthDotNet.Model;

namespace MirthDotNet
{
    /// <remarks>
    /// This code is ported from: https://svn.mirthcorp.com/connect/trunk/server/src/com/mirth/connect/client/core/Client.java
    /// </remarks>
    public class Client
    {
        public const string USER_SERVLET = "/users";
        public const string CHANNEL_SERVLET = "/channels";
        public const string CONFIGURATION_SERVLET = "/configuration";
        public const string CHANNEL_STATUS_SERVLET = "/channelstatus";
        public const string CHANNEL_STATISTICS_SERVLET = "/channelstatistics";
        public const string MESSAGE_SERVLET = "/messages";
        public const string EVENT_SERVLET = "/events";
        public const string ALERT_SERVLET = "/alerts";
        public const string TEMPLATE_SERVLET = "/codetemplates";
        public const string EXTENSION_SERVLET = "/extensions";
        public const string ENGINE_SERVLET = "/engine";

        public Client(string address)
        {
            this.address = address;
            this.connection = new ServerConnection(address);
        }

        public Client(string address, int timeout)
        {
            this.address = address;
            this.timeout = timeout;
            this.connection = new ServerConnection(address, timeout);
        }

        private readonly string address;
        private readonly int timeout;
        private readonly ServerConnection connection;

        private XmlSerializer GetSerializer<T>()
        {
            return new XmlSerializer(typeof(T));
        }

        private T ToObject<T>(string result)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(result)))
            {
                return (T)GetSerializer<T>().Deserialize(stream);
            }
        }

        public LoginStatus Login(string username, string password, string version)
        {
            var data = new Parameters();
            data.Add("op", Operations.USER_LOGIN.Name);
            data.Add("username", username);
            data.Add("password", password);
            data.Add("version", version);
            return ToObject<LoginStatus>(connection.ExecutPostMethod(USER_SERVLET, data));
        }

        public string Logout()
        {
            var data = new Parameters();
            data.Add("op", Operations.USER_PREFERENCES_GET.Name);
            return connection.ExecutPostMethod(USER_SERVLET, data);
        }

        public string GetServerId()
        {
            var data = new Parameters();
            data.Add("op", Operations.CONFIGURATION_SERVER_ID_GET.Name);
            return connection.ExecutPostMethod(CONFIGURATION_SERVLET, data);
        }

        public string GetServerTimezone()
        {
            var data = new Parameters();
            data.Add("op", Operations.CONFIGURATION_SERVER_TIMEZONE_GET.Name);
            return connection.ExecutPostMethod(CONFIGURATION_SERVLET, data);
        }

        public string GetStatus()
        {
            var data = new Parameters();
            data.Add("op", Operations.CONFIGURATION_STATUS_GET.Name);
            return connection.ExecutPostMethod(CONFIGURATION_SERVLET, data);
        }

        public string GetBuildDate()
        {
            var data = new Parameters();
            data.Add("op", Operations.CONFIGURATION_BUILD_DATE_GET.Name);
            return connection.ExecutPostMethod(CONFIGURATION_SERVLET, data);
        }

        public string GetVersion()
        {
            var data = new Parameters();
            data.Add("op", Operations.CONFIGURATION_VERSION_GET.Name);
            return connection.ExecutPostMethod(CONFIGURATION_SERVLET, data);
        }

        public DashboardStatusList GetChannelStatusList()
        {
            var data = new Parameters();
            data.Add("op", Operations.CHANNEL_GET_STATUS.Name);
            var r = connection.ExecutPostMethod(CHANNEL_STATUS_SERVLET, data);
            return ToObject<DashboardStatusList>(r);
        }
    }
}
