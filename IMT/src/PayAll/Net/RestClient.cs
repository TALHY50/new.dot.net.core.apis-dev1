using PayAll.Exception;
using exception = System.Exception;

namespace PayAll.Net
{
    public class RestClient : BaseRestClient
    {

        public static T Get<T>(string url, Dictionary<string, string> headers)
        {
            return Exchange<T>(url, HttpMethod.Get, headers, null);
        }
        public static T Post<T>(string url, Dictionary<string, string> headers, object requestmodel)
        {
            return Exchange<T>(url, HttpMethod.Post, headers, requestmodel);
        }
        public static T Patch<T>(string url, Dictionary<string, string> headers, object request)
        {
            return Exchange<T>(url, HttpMethod.Patch, headers, request);
        }
        public static T Delete<T>(string url, Dictionary<string, string> headers)
        {
           return Exchange<T>(url, HttpMethod.Delete, headers, null);
        }
        private static T Exchange<T>(string url, HttpMethod httpMethod, Dictionary<string, string> headers,object request)
        {
            try
            {
                var requestMessage = BuildHttpRequestMessage(url, httpMethod, headers, request);
                var httpResponseMessage = HttpClient.SendAsync(requestMessage).Result;
                var content = httpResponseMessage.Content.ReadAsByteArrayAsync().Result;
                return HandleResponse<T>(httpResponseMessage, content);
            }
            catch (PayAllException e)
            {
                throw e;
            }
            catch (exception e)
            {
                throw new PayAllException(e);
            }
        }
    }
}