
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using IMT.PayAll.Exception;
using IMT.PayAll.Response;
using IMT.PayAll.Response.Common;
using Newtonsoft.Json;
using exception = System.Exception;

namespace IMT.PayAll.Net
{
    public class RestClient : BaseRestClient
    {

        public static HttpResponseModel Post(string url, Dictionary<string, string> headers, object requestmodel)
        {
            return Exchange(url, HttpMethod.Post, headers, requestmodel);
        }

        public static T Post<T>(string url, Dictionary<string, string> headers, object requestmodel)
        {
            return Exchange<T>(url, HttpMethod.Post, headers, requestmodel);
        }
        public static T Post<T>(string url, Dictionary<string, string> headers)
        {
            return Exchange<T>(url, HttpMethod.Post, headers, null);
        }

        private static T Exchange<T>(string url, HttpMethod httpMethod, Dictionary<string, string> headers,
            object request)
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

        private static HttpResponseModel Exchange(string url, HttpMethod httpMethod, Dictionary<string, string> headers, object request)
        {
            try
            {
                var requestMessage = BuildHttpRequestMessage(url, httpMethod, headers, request);
                var response = HttpClient.SendAsync(requestMessage).Result;
                return HandleResponse(response);
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