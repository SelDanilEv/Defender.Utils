using System;
using System.Security.Cryptography;
using System.Text;

namespace Defender.Utils
{
    public class EncryptionUtils
    {
        public static string GetHashSHA1(string text, string salt = "")
        {
            using (var sha1 = new SHA1Managed())
            {
                byte[] hash = Encoding.UTF8.GetBytes($"{salt}_{text}");
                byte[] generatedHash = sha1.ComputeHash(hash);
                string generatedHashString = Convert.ToBase64String(generatedHash);

                return generatedHashString.Trim('=');
            }
        }

        public static string GetHashSHA256(string text, string salt = "")
        {
            using (var sha1 = new SHA256Managed())
            {
                byte[] hash = Encoding.UTF8.GetBytes($"{salt}_{text}");
                byte[] generatedHash = sha1.ComputeHash(hash);
                string generatedHashString = Convert.ToBase64String(generatedHash);

                return generatedHashString.Trim('=');
            }
        }
    }
}
