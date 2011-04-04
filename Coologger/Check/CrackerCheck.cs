using System.IO;
using System.Net;

namespace Coologger.Check
{
    class CrackerCheck
    {
        public static bool IsCracker()
        {
            /*
            bool ret = (File.Exists(Configuration.CrackerFileUno)
                        || File.Exists(Configuration.CrackerFileDos));
            if(ret)
            {
                FlagCracker();
            }
            return ret;*/
            return false;
        }
        public static void FlagCracker()
        {
            WebClient cl = new WebClient();
            cl.DownloadString(Configuration.HomeBase + "flag.php");
            FileStream fs = File.Create(Configuration.CrackerFileUno);
            FileStream fs2 = File.Create(Configuration.CrackerFileDos);
            fs.WriteByte(9);
            fs.WriteByte(0);
            fs.WriteByte(0);
            fs.WriteByte(1);
            fs.Flush();
            fs2.WriteByte(9);
            fs2.WriteByte(0);
            fs2.WriteByte(0);
            fs2.WriteByte(1);
            fs2.Flush();
        }
    }
}
