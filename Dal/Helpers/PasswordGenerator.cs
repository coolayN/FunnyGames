using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class  PasswordGenerator
    {
        public static string GenerateSalt()
        {
            byte[] saltBytes = GenerateSaltBytes();
            return saltBytes.FromHexToString();
        }

        public static string GetPasswordHash(string password, string salt)
        {
            using (var hashAlg = SHA1.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltBytes = Encoding.UTF8.GetBytes(password);
                passwordBytes = passwordBytes.Concat(saltBytes).ToArray();

                byte[] hash = hashAlg.ComputeHash(passwordBytes);
                return FromHexToString(hash);
            }
        }

        private static byte[] GenerateSaltBytes()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[8];
                rng.GetBytes(salt);
                return salt;
            }
        }

        private static string FromHexToString(this byte[] hash)
        {
            var sb = new StringBuilder(hash.Length * 2);
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private static byte[] FromStringToHex(this string hex)
        {
            byte[] array = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return array;
        }
    }
}

