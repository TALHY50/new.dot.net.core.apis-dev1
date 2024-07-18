using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMT.Thunes.Request.Common;

namespace IMT.Thunes.Adapter
{
    public abstract class BaseAdapter
    {

        private const int RandomStringSize = 8;
        private const string ApiVersionHeaderValue = "v1";
        private const string ClientVersionHeaderValue = "craftgate-dotnet-client";
        private const string ApiKey = "Username";
        private const string ApiSecret = "Password";
        private const string AuthVersionHeaderName = "x-auth-version";
        private const string ClientVersionHeaderName = "x-client-version";
        private const string SignatureHeaderName = "x-signature";
        private const string LanguageHeaderName = "lang";
        private const string RandomChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        protected readonly RequestOptions RequestOptions;

        protected BaseAdapter(RequestOptions requestOptions)
        {
            RequestOptions = requestOptions;
        }

        protected Dictionary<string, string> CreateHeaders(object request, string path,
            RequestOptions requestOptions)
        {
            return CreateHttpHeaders(request, path, requestOptions);
        }

        protected Dictionary<string, string> CreateHeaders(string path, RequestOptions requestOptions)
        {
            return CreateHttpHeaders(null, path, requestOptions);
        }

        private static Dictionary<string, string> CreateHttpHeaders(object request, string path,
            RequestOptions options
        )
        {
            var headers = new Dictionary<string, string>();

            headers.Add(ApiKey, options.ApiKey);
            headers.Add(ApiSecret, options.SecretKey);

            // Basic Authentication
            string credentials = $"{options.ApiKey}:{options.SecretKey}";
            string basicAuthValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
            headers.Add("Authorization", "Basic " + basicAuthValue);

            return headers;
        }

        private static string PrepareAuthorizationString(object request, string path, string randomString,
            RequestOptions options)
        {
            return HashGenerator.GenerateHash(options.BaseUrl, options.ApiKey, options.SecretKey, randomString,
                request, path);
        }

        private static string RandomString(int length)
        {
            var stringChars = new char[length];
            var random = new Random();
            for (var i = 0; i < stringChars.Length; i++)
                stringChars[i] = RandomChars[random.Next(RandomChars.Length)];
            return new string(stringChars);
        }

    }
}