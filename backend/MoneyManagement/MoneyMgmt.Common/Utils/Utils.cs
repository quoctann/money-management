using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyMgmt.Common.Utils
{
    public class Utils
    {
        /// <summary>
        /// Hash a string by MD5 algorithm
        /// </summary>
        /// <param name="input">Original string</param>
        /// <returns>MD5 hash of string</returns>
        public static string GetMD5HashOfString(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < hash.Length; j++)
            {
                sb.Append(hash[j].ToString("X2"));
            }

            return sb.ToString().ToLower();
        }
    }
}
