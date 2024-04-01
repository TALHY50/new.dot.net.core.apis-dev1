using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using SharedLibrary.Repositories;
using SharedLibrary.Utilities;

namespace SharedLibrary.Services;


public class IdGenerator
{
    public IUnitOfWork UnitOfWork;

    public IdGenerator(IUnitOfWork unitOfWork = null)
    {
        if (unitOfWork != null)
        {
            UnitOfWork = null;
        }
    }
    
    
    public static string GenerateUniqueKey(string uniqueString = "")
    {
        string token = "";

        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(uniqueString + DateTime.Now.Ticks.ToString());
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2")); // Convert bytes to hex string
            }
            token = sb.ToString() + GetRandomString();
        }

        return token;
    }
    
    
    public static string GenerateOrderId()
    {
        string orderId = string.Empty;
        int timePart = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

        Random random = new Random();
        orderId = string.Concat(timePart, random.Next(10000, 99999));
        return orderId;
    }

    public string GeneratePaymentId(int dataId, string currencyRelatable, string paymentType, Merchant? merchant = null, int? userId = null, string type = "merchantSec")
    {
        int dateMonthYear = Clocker.DateMonthYear(DateTime.Now);

        if (type == "merchantSec")
        {
            if (null == merchant && null != userId)
            {
                var merchantRepository = new MerchantRepository(UnitOfWork);
                merchant = merchantRepository.FindByUserId((int)userId);
            }

            var padded = "";

            if (null != merchant)
            {

                 padded = Str.PadLeft(merchant.Id.ToString(), 5, '0');
            }
            else
            {
                padded = Str.PadLeft(userId.ToString(), 5, '0');
            }

            var newRand = GetRandomString() + "-" + AlphaID(dataId);



            var result = newRand + "-"+ currencyRelatable + paymentType + "-" + padded + "-" + dateMonthYear.ToString();


            return result;




        }

        return "";

    }


    public static string GetRandomString(int stringLength = 5)
    {
        string permitted_chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        Random random = new Random();

        // Shuffle the permitted_chars and take the first 'len' characters
        string randomString = new string(permitted_chars
            .OrderBy(c => random.Next())
            .Take(stringLength)
            .ToArray());

        return randomString;
    }
    
    public static string AlphaID(int input, bool toAlpha = false, int padUp = 0, string passKey = null)
    {
        string index = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        if (!string.IsNullOrEmpty(passKey))
        {
            var i = index.Select(c => c.ToString()).ToArray();

            var passHash = BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(passKey))).Replace("-", "");
            passHash = (passHash.Length < index.Length) ? BitConverter.ToString(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(passKey))).Replace("-", "") : passHash;

            var p = passHash.Select(c => c.ToString()).ToArray();
            Array.Sort(p, i);
            index = string.Join("", i);
        }

        var @base = index.Length;

        if (toAlpha)
        {
            if (padUp > 0)
            {
                input -= (int)Math.Pow(@base, padUp);
            }

            var output = "";
            var t = (int)Math.Floor(Math.Log(input, @base));

            for (; t >= 0; t--)
            {
                var bcp = (long)Math.Pow(@base, t);
                var a = (int)Math.Floor((decimal)(input / bcp)) % @base;
                output += index[a];
                input -= (int)(a * bcp);
            }

            return new string(output.Reverse().ToArray());
        }
        else
        {
            if (padUp > 0)
            {
                input += (int)Math.Pow(@base, padUp);
            }

            long output = 0;
            var len = input.ToString().Length - 1;

            for (var t = 0; t <= len; t++)
            {
                var bcpow = (long)Math.Pow(@base, len - t);
                output += index.IndexOf(input.ToString()[t]) * bcpow;
            }

            return output.ToString();
        }
    }
    
    
    private static readonly Random random = new Random();
        
    public static string GetSecretKey(int length = 32)
    {
        const string characters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int charactersLength = characters.Length;
        StringBuilder randomString = new StringBuilder(length);
            
        for (int i = 0; i < length; i++)
        {
            randomString.Append(characters[random.Next(charactersLength)]);
        }

        return randomString.ToString();
    }
    
    
    public static string UniqueString(string uniqueString)
    {
        string secretKey = GetSecretKey();

        string concatenatedString = uniqueString + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString() + secretKey;

        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(concatenatedString);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
    
    public static string ConvertBase(string input, bool toNum = false, int padUp = -1)
    {
        input = Str.ExtractNumbers(input);
        
        string index = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int baseValue = index.Length;
        BigInteger outValue = 0;

        if (toNum)
        {
            input = Str.ReverseString(input);

            for (int t = 0; t < input.Length; t++)
            {
                BigInteger bcpow = BigInteger.Pow(baseValue, input.Length - t - 1);
                outValue += index.IndexOf(input[t]) * bcpow;
            }

            if (int.TryParse(padUp.ToString(), out int padUpNum))
            {
                padUpNum--;
                if (padUpNum > 0)
                {
                    outValue -= BigInteger.Pow(baseValue, padUpNum);
                }
            }
        }
        else
        {
            if (int.TryParse(padUp.ToString(), out int padUpNum))
            {
                padUpNum--;
                if (padUpNum > 0)
                {
                    outValue += BigInteger.Pow(baseValue, padUpNum);
                }
            }

            string outStr = "";
            BigInteger inValue = BigInteger.Parse(input);

            for (int t = (int)Math.Floor(BigInteger.Log(inValue, baseValue)); t >= 0; t--)
            {
                BigInteger a = BigInteger.Divide(inValue, BigInteger.Pow(baseValue, t));
                outStr += index[(int)a];
                inValue -= a * BigInteger.Pow(baseValue, t);
            }

            char[] charArray = outStr.ToCharArray();
            Array.Reverse(charArray);
            outStr = new string(charArray);
            return outStr;
        }

        return outValue.ToString();
    }
    
    
    
    public static string GenerateRandomString(int length)
    {
        const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    
    
    
    public static string GenerateUniqueCode(string uniqueCode)
    {
        uniqueCode = ConvertBase(uniqueCode);
        uniqueCode = $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}{uniqueCode}";

        if (uniqueCode.Length < 16)
        {
            uniqueCode += GenerateRandomString(16 - uniqueCode.Length);
        }

        uniqueCode = uniqueCode.Substring(0, Math.Min(uniqueCode.Length, 16));

        return uniqueCode;
    }

    

}
