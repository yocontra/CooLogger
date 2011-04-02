using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;

namespace Coologger
{
    public class Util
    {

        public static string randomString(int length)
        {
            const string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            StringBuilder builder = new StringBuilder(length);
            int i;
            for (i = 0; i <= length - 1; i++)
            {
                int num2 = random.Next(str.Length);
                builder.Append(str[num2]);
            }
            return Convert.ToString(builder);
        }

        public static string encryptMe(string sData)
        {
            SHA1Managed mSHA = new SHA1Managed();
            byte[] dString = Encoding.ASCII.GetBytes(sData);
            string cString = Convert.ToBase64String(dString);
            return cString;
        }

        private static readonly byte[] key = {
                                          1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,
                                          12, 13, 14, 15, 16, 17, 18, 19, 20,
                                          21, 22, 23, 24
                                      };
        private static readonly byte[] iv = { 8, 7, 6, 5, 4, 3, 2, 1 };
        public static cTripleDES des = new cTripleDES(key, iv);

        public static string ObfuscateString(string sInput)
        {
            string sTemp = null;
            int iLoop, iLen;

            iLen = sInput.Length;
            for (iLoop = iLen; iLoop >= 1; iLoop += -2)
            {
                sTemp += Strings.Mid(sInput, iLoop, 1);
            }
            for (iLoop = iLen - 1; iLoop >= 1; iLoop += -2)
            {
                sTemp += Strings.Mid(sInput, iLoop, 1);
            }

            return sTemp;
        }
    }
}
