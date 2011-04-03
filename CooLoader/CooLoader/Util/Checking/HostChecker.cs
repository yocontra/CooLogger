using System;
using System.Net.NetworkInformation;
using System.IO;

namespace CooLoader.Util.Checking
{
    internal class HostChecker
    {
        private bool _ping;

        public HostChecker(bool ping)
        {
            _ping = ping;
        }
        private bool Ping()
        {
            PingReply pingReply = new Ping().Send("coologger.net");
            return pingReply != null && pingReply.Address.ToString() == "50.22.80.58";
        }

        public bool IsValid()
        {
            if (_ping)
            {
                return Ping();
            }
            string hosts = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\drivers\\etc\\hosts";
            StreamReader sr = File.OpenText(hosts);
            string contents = sr.ReadLine();
            while (sr.ReadLine() != null)
            {
                contents += sr.ReadLine();
            }
            sr.Close();
            if (contents == null)
            {
                return true;
            }
            return !contents.Contains("coologger");
        }
    }
}