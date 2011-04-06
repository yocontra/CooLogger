using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Coologger.Check
{
    internal class FileHasher
    {
        private string _loc;

        public FileHasher(string loc)
        {
            _loc = loc;
        }

        public string GetMD5()
        {
            FileStream file = new FileStream(_loc, FileMode.Open, FileAccess.Read);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString().ToUpper();
        }
    }
}