

using IMT.PayAll.Request.Common;
using IMT.PayAll.Route;


namespace IMT.PayAll.Adapter
{
    public abstract class BaseAdapter
    {

        private const string Accept = "accept";
        private const string Authorization = "authorization";
        private const string acceptHeader = "application/json";
        protected readonly RequestOptions RequestOptions;

        protected BaseAdapter(RequestOptions requestOptions)
        {
            RequestOptions = requestOptions;
        }

        protected Dictionary<string, string> CreateHeaders(object request, string path,RequestOptions requestOptions)
        {
            return CreateHttpHeaders(request, path, requestOptions);
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

        private static string PrepareAuthorization(RequestOptions options)
        {
            var path = PayAllUrl.Auth;
            //RestClient.Post(RequestOptions.BaseUrl + path, CreateHeaders(null, path, RequestOptions), null);

            return "Bearer 123456789adffsfsfsfasfdfsdfadfsfsf";
        }
    }
}