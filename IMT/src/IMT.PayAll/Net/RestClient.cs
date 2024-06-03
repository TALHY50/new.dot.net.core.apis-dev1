
using IMT.PayAll.Exception;
using IMT.PayAll.Response.Common;
using exception = System.Exception;

namespace IMT.PayAll.Net
{
    public class RestClient : BaseRestClient
    {

        public static HttpResponse<T> Get<T>(string url, Dictionary<string, string> headers)
        {
            return Exchange<T>(url, HttpMethod.Get, headers, null);
        }
        public static HttpResponse<T> Post<T>(string url, Dictionary<string, string> headers, object requestmodel)
        {
            return Exchange<T>(url, HttpMethod.Post, headers, requestmodel);
        }
        public static HttpResponse<T> Patch<T>(string url, Dictionary<string, string> headers, object request)
        {
            return Exchange<T>(url, HttpMethod.Patch, headers, request);
        }
        private static HttpResponse<T> Exchange<T>(string url, HttpMethod httpMethod, Dictionary<string, string> headers,object request)
        {
            try
            {
                var requestMessage = BuildHttpRequestMessage(url, httpMethod, headers, request);
                var httpResponseMessage = HttpClient.SendAsync(requestMessage).Result;
                var content = httpResponseMessage.Content.ReadAsStringAsync().Result;
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