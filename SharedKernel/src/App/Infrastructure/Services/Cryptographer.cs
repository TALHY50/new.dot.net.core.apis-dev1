using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using App.Application.Constants;
using App.Infrastructure.Attributes;
using App.Infrastructure.Utilities;

namespace App.Infrastructure.Services
{
#pragma warning disable CS8629 // Possible null reference argument.
    public static class Cryptographer
    {
 
        public static bool IsValidHashKey<T>(T targetContent, string hashKey, string appSecret) where T : new()
        {
            bool isValid = false;

            if (string.IsNullOrEmpty(hashKey) || string.IsNullOrEmpty(appSecret)) { return false; }

            var sourceContent = OriginateContentFromHashKey<T>(hashKey, appSecret);

            var jsonSourceContent = Json.Serialize(sourceContent);

            var jsonTargetContent = Json.Serialize(targetContent);
            
            isValid = jsonSourceContent == jsonTargetContent;

            return isValid;
        }
        
        
        public static T OriginateContentFromHashKey<T>(string hashKey, string appSecret) where T : new()
        {

            var content = new T();
            
            hashKey = hashKey.Replace("__", "/");

            string password = Sha1Hash(appSecret);

            IList<string> mainStringArray = hashKey.Split(':').ToList<string>();

            if (mainStringArray.Count == 3)
            {
                string iv = mainStringArray[0];
                string salt = mainStringArray[1];
                string mainKey = mainStringArray[2];
                
                string saltWithPassword = "";
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    saltWithPassword = GetHash(sha256Hash, password + salt);
                }
                string originalValues = DecryptMessage(mainKey, saltWithPassword.Substring(0, 32), iv);
                IList<string> valueList = originalValues.Split('|').ToList<string>();

                 content = AssignValuesToContent<T>(valueList);
            }

            return content;

        }
        
        
        public static T AssignValuesToContent<T>(IList<string> valueList) where T : new()
        {
            T content = new T();
            PropertyInfo[] properties = typeof(T).GetProperties()
                .OrderBy(p => GetPropertyOrder(p))
                .ToArray();

            for (int i = 0; i < Math.Min(properties.Length, valueList.Count); i++)
            {
                properties[i].SetValue(content, valueList[i]);
            }

            return content;
        }

        private static int GetPropertyOrder(PropertyInfo property)
        {
            var orderAttribute = property.GetCustomAttribute<PropertyOrderAttribute>();
            return orderAttribute?.Order ?? int.MaxValue;
        }

        
        
        
        public static string EncryptOrDecrypt(string value, string secretKey, string action, bool isURL = false, string iv = "", string salt = "")
        {
            if (action == "encrypt")
            {
                value = Encrypt(value, secretKey, iv, salt);

                if (isURL)
                {
                    value = value.Replace("/", "__");
                }

                return value;

            }
            else if (action == "decrypt")
            {

                if (isURL)
                {
                    value = value.Replace("__", "/");
                }

                var result = Decrypt(value, secretKey);
                return result;
            }

            return value;
        }
        
        
        public static string EncryptOrDecrypt<T>(T values, string secretKey, string action, bool isURL = false, string iv = "", string salt = "")
        {
            string? data = "";
            if (typeof(T) == typeof(string[]))
            {
                string[]? reflectedValues  = values as string[];

                if (reflectedValues != null)
                {
                    for (int i = 0; i < reflectedValues.Length; i++)
                    {
                        if (i == reflectedValues.Length - 1)
                        {
                            data += reflectedValues[i];
                        }
                        else
                        {
                            data += reflectedValues[i] + "|";
                            
                        }
                    }
                    
                }
            }
            else
            {
                
                data = values as string;

            }

            return EncryptOrDecrypt(data??"", secretKey, action, isURL, iv, salt);

        }
        
        private static string Encryptor(string textToEncrypt, string strKey, string strIv)
        {
            //Turn the plaintext into a byte array.
            byte[] plainTextBytes = global::System.Text.Encoding.UTF8.GetBytes(textToEncrypt);

            Aes aesProvider = Aes.Create();
            aesProvider.BlockSize = 128;

            aesProvider.KeySize = 256;

            aesProvider.Key = global::System.Text.Encoding.UTF8.GetBytes(strKey);
            aesProvider.IV = global::System.Text.Encoding.UTF8.GetBytes(strIv);
            aesProvider.Padding = PaddingMode.PKCS7;
            aesProvider.Mode = CipherMode.CBC;

            ICryptoTransform cryptoTransform = aesProvider.CreateEncryptor(aesProvider.Key, aesProvider.IV);
            byte[] encryptedBytes = cryptoTransform.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
            return Convert.ToBase64String(encryptedBytes);
        }
 
        private static string DecryptMessage(string msg, string key, string iv = "")
        {
            //msg = msg.Replace("__", "/");
            byte[] encryptedBytes = Convert.FromBase64String(msg);
           
            Aes aesProvider = Aes.Create();

            aesProvider.BlockSize = 128;
            aesProvider.KeySize = 256;
           
            aesProvider.Key = global::System.Text.Encoding.ASCII.GetBytes(key);
            aesProvider.IV = global::System.Text.Encoding.ASCII.GetBytes(iv);
            aesProvider.Padding = PaddingMode.PKCS7;
            aesProvider.Mode = CipherMode.CBC;


            ICryptoTransform cryptoTransform = aesProvider.CreateDecryptor(aesProvider.Key, aesProvider.IV);
            byte[] decryptedBytes = cryptoTransform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            return global::System.Text.Encoding.ASCII.GetString(decryptedBytes);
        }
        

 
        public static string HashSha256(string password, string salt = "")
        {
            string saltWithPassword;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                saltWithPassword = GetHash(sha256Hash, password + salt);
            }

            return saltWithPassword;
        }

        #region Private Methods
        static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        static string Sha1Hash(string password)
        {
            return string.Join("", SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("x2")));
        }

        static string Encrypt(string data, string password, string iv = "", string salt = "")
        {
            Random mt_rand = new Random();

            if (string.IsNullOrEmpty(data))
            {
                return data;
            }
            if (string.IsNullOrEmpty(iv))
            {
                iv = Sha1Hash(mt_rand.Next().ToString()).Substring(0, 16);
            }

            password = Sha1Hash(password);

            if (string.IsNullOrEmpty(salt))
            {
                salt = Sha1Hash(mt_rand.Next().ToString()).Substring(0, 4);
            }
            string saltWithPassword = HashSha256(password, salt);

            string encrypted = Encryptor(data, saltWithPassword.Substring(0, 32), iv);

            string msg_encrypted_bundle = iv + ":" + salt + ":" + encrypted;
            //msg_encrypted_bundle = msg_encrypted_bundle.Replace("/", "__");

            return msg_encrypted_bundle;
        }

        

        public static string Decrypt(string msg, string key)
        {
            if (string.IsNullOrEmpty(msg))
            {
                return msg;
            }

            key = Sha1Hash(key);

            var components = msg.Split(':');

            if (components.Length < 3)
            {
                return msg;
            }

            var iv = components[0] ?? "";
            var salt = components[1] ?? "";

            string saltWithPassword = HashSha256(key, salt); ;
            
            var encryptedMsg = components[2] ?? "";

            var decryptedMsg = DecryptMessage(encryptedMsg, saltWithPassword.Substring(0, 32), iv);

            return decryptedMsg;
        }

       public static string AppDecrypt(string msg)
        {
            return Decrypt(msg, Constants.BRAND_SECRET_KEY);
        }

       public static string AppEncrypt(string msg)
       {
            return Encrypt(msg, Constants.BRAND_SECRET_KEY);
        }
       
       
       
       public static string Mask(string value, int firstPartLength = 0, int? lastPartLength = 0)
       {
           if (string.IsNullOrEmpty(value))
           {
               return string.Empty;
           }
           value = value.Replace(" ", "");
           int length = value.Length;
           if (firstPartLength == 0 && lastPartLength == 0)
           {
               switch (length)
               {
                   case 1:
                       firstPartLength = 0;
                       lastPartLength = 0;
                       break;

                   case 2:
                       firstPartLength = 0;
                       lastPartLength = 0;
                       break;

                   case 3:
                       firstPartLength = 0;
                       lastPartLength = 0;
                       break;

                   case 4:
                       firstPartLength = 1;
                       lastPartLength = 1;
                       break;

                   case 5:
                       firstPartLength = 2;
                       lastPartLength = 1;
                       break;

                   case 6:
                       firstPartLength = 2;
                       lastPartLength = 2;
                       break;

                   case 7:
                       firstPartLength = 3;
                       lastPartLength = 2;
                       break;

                   case 8:
                       firstPartLength = 4;
                       lastPartLength = 2;
                       break;
                   case 9:
                       firstPartLength = 4;
                       lastPartLength = 2;
                       break;
                   case 10:
                       firstPartLength = 4;
                       lastPartLength = 3;
                       break;
                   case 11:
                       firstPartLength = 4;
                       lastPartLength = 4;
                       break;
                   case 12:
                       firstPartLength = 6;
                       lastPartLength = 4;
                       break;

                   case 13:
                       firstPartLength = 6;
                       lastPartLength = 4;
                       break;

                   default:
                       firstPartLength = 6;
                       lastPartLength = 4;
                       break;
               }
           }
           
           string firstPart = value.Substring(0, firstPartLength);
           string middlePart = new string('*', (int)(length - (firstPartLength + lastPartLength)));
           string lastPart = value.Substring((int)(length- lastPartLength));
           
           
           return $"{firstPart}{middlePart}{lastPart}";
       }

       

        #endregion
        
    }
}
