using System;
using System.Threading;
using CooLoader.Util.Net;

namespace CooLoader.Util.Checking
{
    internal class HeartBeat
    {
        public void Beat()
        {
            while (true)
            {
                if (!new PhoneHome("beat.php").Call().Contains("thump"))
                {
                    //Environment.Exit(1337);
                }
                Thread.Sleep(30000);
            }
        }
    }
}