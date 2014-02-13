using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace MirthDotNet
{
    public class MirthCertificateHandler
    {
        static MirthCertificateHandler()
        {
            // This will disable SSL certificate validation but useful for dev environments
            originalCallback = ServicePointManager.ServerCertificateValidationCallback;
            ServicePointManager.ServerCertificateValidationCallback = HandleCert;
        }

        private static RemoteCertificateValidationCallback originalCallback;
        public static bool HandleCert(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            bool originalCallbackResult = false;
            if (originalCallback != null)
            {
                originalCallbackResult = originalCallback(sender, certificate, chain, sslPolicyErrors);
            }
            if (sender is HttpWebRequest)
            {
                var uri = ((HttpWebRequest)sender).RequestUri;
                return HostWhiteListContains(uri.Host);
            }
            return originalCallbackResult;
        }
        private static readonly ReaderWriterLockSlim hostWhiteListLock = new ReaderWriterLockSlim();
        private static readonly HashSet<string> hostWhiteList = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

        public static bool AddHostToWhiteList(string host)
        {
            try
            {
                hostWhiteListLock.EnterWriteLock();
                return hostWhiteList.Add(host);
            }
            finally
            {
                if (hostWhiteListLock.IsWriteLockHeld)
                {
                    hostWhiteListLock.ExitWriteLock();
                }
            }
        }
        public static bool HostWhiteListContains(string host)
        {
            try
            {
                hostWhiteListLock.EnterReadLock();
                return hostWhiteList.Contains(host);
            }
            finally
            {
                if (hostWhiteListLock.IsReadLockHeld)
                {
                    hostWhiteListLock.ExitReadLock();
                }
            }
        }
    }
}
