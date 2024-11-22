using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TVSeriesReviews.WPF.Models.Data
{
    public class Security
    {
        private const int SaltSize = 16;
        private const int HashSize = 32; 
        private const int Iterations = 100000;

        public static string HashPassword(string password, out byte[] salt)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                salt = new byte[SaltSize];
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);

                return Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string password, string hash, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] computedHash = pbkdf2.GetBytes(HashSize);
                byte[] storedHash = Convert.FromBase64String(hash);

                return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
            }
        }
    }
}
