using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DefenderUniversalLibrary
{
    public class Encryption_Lib
    {
        public static string GetHashSHA1(string text)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = Encoding.UTF8.GetBytes(text);
                byte[] generatedHash = sha1.ComputeHash(hash);
                string generatedHashString = Convert.ToBase64String(generatedHash);

                return generatedHashString.Trim('=');
            }
        }
    }
}
