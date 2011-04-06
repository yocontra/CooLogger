using System;
using System.Threading;

namespace Coologger.Check
{
    internal class HeartBeat
    {
        public void Beat()
        {
            while (true)
            {
                if(CrackerCheck.IsCracker())
                {
                    Environment.Exit(9001);
                }
                HostChecker chk = new HostChecker(false);
                if (!chk.IsValid())
                {
                    CrackerCheck.FlagCracker();
                }
                if (!RemoteSettings.GrabSetting("beat.php").Contains("thump"))
                {
                    Environment.Exit(1337);
                }
                Thread.Sleep(30000);
            }
        }
    }
}