using System;
using System.Net;
using CooLoader.Util.Encryption;

namespace Coologger.Check
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
            cl.Headers.Add("coo-hash", new FileHasher(Configuration.RunningLocation).GetMD5());
            cl.Headers.Add("coo-hwid", Global.HID);
            string ret = cl.DownloadString(_url);
            if(ret.Contains("c1090c"))
            {
                CrackerCheck.FlagCracker();    
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