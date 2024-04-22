using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class CryptoGenerator
    {
        private HMACSHA256 hmac;
        private byte[] key;

        public CryptoGenerator()
        {
            key = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }
            hmac = new HMACSHA256(key);
        }

        public string GenerateHMAC(string message)
        {
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            return BitConverter.ToString(hash).Replace("-", "").ToUpper();
        }

        public string GetKey()
        {
            return BitConverter.ToString(key).Replace("-", "").ToUpper();
        }
    }
}
