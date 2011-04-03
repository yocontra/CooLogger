namespace Coologger.Check
{
    internal class RemoteSettings
    {
        public static string GrabSetting(string file)
        {
            PhoneHome p = new PhoneHome(file);
            return p.Call();
        }
    }
}