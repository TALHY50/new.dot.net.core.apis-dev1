using System.Security.Cryptography;
using System.Text;
using App.Domain.Ports.Services.Cryptography;
using Konscious.Security.Cryptography;

namespace App.Infrastructure.Services.Cryptography
{
    // For good password practices go here: https://crackstation.net/hashing-security.htm
    // https://github.com/kmaragon/Konscious.Security.Cryptography
    public class CryptographyService : ICryptographyService
    {
        private const int HashSize = 64;

        public CryptographyService() { }
     
        public string GenerateSalt()
        {
            var buffer = new byte[HashSize];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

        public string HashPassword(string password, string salt)
        {
            var argon2 = new Argon2i(Encoding.UTF8.GetBytes(password))
            {
                DegreeOfParallelism = 16,
                MemorySize = 8192,
                Iterations = 40,
                Salt = Encoding.UTF8.GetBytes(salt)
            };

            var hash = argon2.GetBytes(HashSize);
            return Convert.ToBase64String(hash);
        }
    }
}