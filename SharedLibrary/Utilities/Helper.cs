using SharedLibrary.Constants;
using SharedLibrary.Models;
using System.Security.Cryptography;
using System.Text;
using static SharedLibrary.Constants.Constants;
using System;

namespace SharedLibrary.Utilities
{
    public static class Helper
    {

        public static string GetLanguage(string inputLanguage, string currencyCode)
        {
            string language = "tr";

            if (!string.IsNullOrEmpty(inputLanguage) && Constants.Constants.SYSTEM_SUPPORTED_LANGUAGE.Contains(inputLanguage.ToLower()))
            {
                language = inputLanguage;
            }
            else
            {
                if (!string.IsNullOrEmpty(currencyCode))
                {
                    if (currencyCode == Models.Currency.TRY_CODE)
                    {
                        language = "tr";
                    }
                    else
                    {
                        language = "en";
                    }
                }
            }

            return language;
        }

        public static string __(string Text)
        {
            return Text;
        }


        public static string Bcrypt(string text)
        {
            // Generate a random salt
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Create the Rfc2898DeriveBytes object and get the hash value
            using (var pbkdf2 = new Rfc2898DeriveBytes(text, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20); // 20 is the size of the hash
                byte[] hashBytes = new byte[36]; // 20 bytes for hash + 16 bytes for salt
                Array.Copy(salt, 0, hashBytes, 0, 16); // Copy salt bytes to hash bytes
                Array.Copy(hash, 0, hashBytes, 16, 20); // Copy hash bytes to hash bytes
                return Convert.ToBase64String(hashBytes); // Convert to Base64 string
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Extract the salt from the hashed password
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Compute the hash of the provided password using the same salt
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                // Compare the computed hash with the stored hash
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        return false; // Passwords don't match
                    }
                }
                return true; // Passwords match
            }
        }

        public static string GenerateUniqueKey(string email)
        {
            // Hash the email address using SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(email));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

    }
}
