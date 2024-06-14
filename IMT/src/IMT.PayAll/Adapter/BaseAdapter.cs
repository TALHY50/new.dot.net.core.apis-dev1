

using IMT.PayAll.Net;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Response;
using IMT.PayAll.Route;


namespace IMT.PayAll.Adapter
{
    public abstract class BaseAdapter
    {

        private const string Accept = "accept";
        private const string Authorization = "authorization";
        private const string acceptHeader = "application/json";
        private const string X_API_Key = "X-API-Key";
        protected readonly RequestOptions RequestOptions;

        protected BaseAdapter(RequestOptions requestOptions)
        {
            RequestOptions = requestOptions;
        }

        protected Dictionary<string, string> CreateHeaders(object request, string path,RequestOptions requestOptions)
        {
            return CreateHttpHeaders(request, path, requestOptions);
        }
        protected Dictionary<string, string> CreateHeadersForEvent(object request, string path, RequestOptions requestOptions)
        {
            return CreateHttpEventHeaders(request, path, requestOptions);
        }

        protected Dictionary<string, string> CreateHeaders(string path, RequestOptions requestOptions)
        {
            return CreateHttpHeaders(null, path, requestOptions);
        }

        private static Dictionary<string, string> CreateHttpHeaders(object request, string path,RequestOptions options)
        {
            var headers = new Dictionary<string, string>();

            var BearerToken = PrepareAuthorization(options);

            headers.Add(Accept, acceptHeader);
            headers.Add(Authorization, BearerToken);
            return headers;
        }
        private static Dictionary<string, string> LoginHeaders(string path, RequestOptions options)
        {
            var headers = new Dictionary<string, string>();
            headers.Add(Accept, acceptHeader);
            return headers;
        }
        private static Dictionary<string, string> CreateHttpEventHeaders(object request, string path, RequestOptions options)
        {
            var headers = new Dictionary<string, string>();
            headers.Add(X_API_Key, options.API_Key);
            return headers;
        }

        private static string PrepareAuthorization(RequestOptions options)
        {
            var data = options.ClientID + options.ClientSecret;
            var path = PayAllUrl.Auth.Replace("{data}", data.ToString());

            //var response = RestClient.Get<TokenResponse>(options.BaseUrl + path, LoginHeaders(path, options));
            //return "Bearer " + response.access_token;

            return "Bearer 123456789adffsfsfsfasfdfsdfadfsfsf";
        }
    }
}