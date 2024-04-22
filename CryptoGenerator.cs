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
            InitializeCrypto();
        }

        private void InitializeCrypto()
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
            InitializeCrypto(); 
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] hash = hmac.ComputeHash(messageBytes);
            return BitConverter.ToString(hash).Replace("-", "").ToUpper();
        }

        public string GetKey()
        {
            return BitConverter.ToString(key).Replace("-", "").ToUpper();
        }
    }

}
