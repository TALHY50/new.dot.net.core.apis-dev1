using System.Collections.Generic;
using System.Net.Http;
using IMT.Thunes.Exception;
using _exception = System.Exception;

namespace IMT.Thunes.Net
{
    public class RestClient : BaseRestClient
    {
        public static T Get<T>(string url, Dictionary<string, string> headers)
        {
            return Exchange<T>(url, HttpMethod.Get, headers, null);
        }

        public static T Post<T>(string url, Dictionary<string, string> headers, object request)
        {
            return Exchange<T>(url, HttpMethod.Post, headers, request);
        }

        public static T Put<T>(string url, Dictionary<string, string> headers, object request)
        {
            return Exchange<T>(url, HttpMethod.Put, headers, request);
        }

        public static T Put<T>(string url, Dictionary<string, string> headers)
        {
            return Exchange<T>(url, HttpMethod.Put, headers, null);
        }

        public static void Delete<T>(string url, Dictionary<string, string> headers)
        {
            Exchange<T>(url, HttpMethod.Delete, headers, null);
        }

        private static T Exchange<T>(string url, HttpMethod httpMethod, Dictionary<string, string> headers,
            object request)
        {
            try
            {
                var requestMessage = BuildHttpRequestMessage(url, httpMethod, headers, request);
                var httpResponseMessage = HttpClient.SendAsync(requestMessage).Result;
                var content = httpResponseMessage.Content.ReadAsStringAsync().Result;
                return (T)HandleResponse<T>(httpResponseMessage, content);
            }
            catch (_exception e)
            {
                throw new ThunesException(e);
            }
        }
        public static object PostObject<T>(string url, Dictionary<string, string> headers, object request)
        {
            return ExchangeObject<T>(url, HttpMethod.Post, headers, request);
        }
        private static object ExchangeObject<T>(string url, HttpMethod httpMethod, Dictionary<string, string> headers,
            object request)
        {
            try
            {
                var requestMessage = BuildHttpRequestMessage(url, httpMethod, headers, request);
                var httpResponseMessage = HttpClient.SendAsync(requestMessage).Result;
                var content = httpResponseMessage.Content.ReadAsStringAsync().Result;
                return HandleObjectResponse<T>(httpResponseMessage, content);
            }
            catch (_exception e)
            {
                throw new ThunesException(e);
            }
        }
        //private static T Exchange<T>(string url, HttpMethod httpMethod, Dictionary<string, string> headers, object request)
        //{
        //    try
        //    {
        //        var requestMessage = BuildHttpRequestMessage(url, httpMethod, headers, request);
        //        var httpResponseMessage = HttpClient.SendAsync(requestMessage).Result;
        //        var content = httpResponseMessage.Content.ReadAsStringAsync().Result;
        //        return HandleResponse<T>(httpResponseMessage, content);
        //    }
        //    catch (_exception e)
        //    {
        //        throw new ThunesException(e);
        //    }
        //}
    }
}