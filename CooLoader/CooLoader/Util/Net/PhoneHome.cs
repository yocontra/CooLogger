using System;
using System.Net;
using CooLoader.Util.Encryption;
using CooLoader.Util.Time;

namespace CooLoader.Util.Net
{
    internal class PhoneHome
    {
        private string _url;

        public PhoneHome(string file)
        {
            _url = Configuration.HomeBase + file;
        }

        public string Call()
        {
            Console.WriteLine(GetURL());
            WebClient cl = new WebClient();
            cl.Headers.Add("coo-version", Configuration.LocalVersion.ToString());
            cl.Headers.Add("coo-time", new DateTime().CurrentTimeMillis().ToString());
            cl.Headers.Add("coo-hash", new FileHasher(Configuration.RunningLocation).GetMD5());
            string ret = cl.DownloadString(_url);
            if(ret.Contains("c1090c"))
            {
                Checking.CrackerCheck.FlagCracker();    
            }
            Console.WriteLine(ret);
            return ret;
        }

        public string GetURL()
        {
            return _url;
        }
    }
}