using System;
using System.Reflection;

namespace CooLoader.Util.Encryption
{
    class EncryptedAssembly
    {
        private Assembly _asm;
        public EncryptedAssembly(string file, string key)
        {
            byte[] rlasm = Convert.FromBase64String(Crypto.DecryptStringAES(file, key));
            _asm = Assembly.Load(rlasm);
        }
        public Assembly GetAssembly()
        {
            return _asm;
        }
    }
}
