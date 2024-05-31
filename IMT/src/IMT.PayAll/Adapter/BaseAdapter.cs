

using IMT.PayAll.Request.Common;


namespace IMT.PayAll.Adapter
{
    public abstract class BaseAdapter
    {

        private const string Accept = "accept";
        private const string Authorization = "authorization";

        private const int RandomStringSize = 8;
        private const string ApiVersionHeaderValue = "v1";
        private const string ClientVersionHeaderValue = "craftgate-dotnet-client";
        private const string ApiKeyHeaderName = "x-api-key";
        private const string RandomHeaderName = "x-rnd-key";
        private const string AuthVersionHeaderName = "x-auth-version";
        private const string ClientVersionHeaderName = "x-client-version";
        private const string SignatureHeaderName = "x-signature";
        private const string LanguageHeaderName = "lang";
        private const string RandomChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const string acceptHeader = "application/json";
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

            var BearerToken = PrepareAuthorization(options);

            //var randomString = RandomString(RandomStringSize);
            //headers.Add(ApiKeyHeaderName, options.ApiKey);
            //headers.Add(RandomHeaderName, randomString);
            //headers.Add(AuthVersionHeaderName, ApiVersionHeaderValue);
            //headers.Add(ClientVersionHeaderName, ClientVersionHeaderValue + ":1.0.59");
            //headers.Add(SignatureHeaderName, PrepareAuthorizationString(request, path, randomString, options));
            //if (options.Language != null)
            //{
            //    headers.Add(LanguageHeaderName, options.Language);
            //}

            headers.Add(Accept, acceptHeader);
            headers.Add(Authorization, BearerToken);
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

        private static string PrepareAuthorization(RequestOptions options)
        {
            var path = "/oauth/token";
            //RestClient.Post(RequestOptions.BaseUrl + path, CreateHeaders(null, path, RequestOptions), null);

            return "Bearer 123456789adffsfsfsfasfdfsdfadfsfsf";
        }
    }
}