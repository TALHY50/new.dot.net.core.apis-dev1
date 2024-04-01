using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using SharedLibrary.Exceptions;

namespace SharedLibrary.Utilities;


    public class RestClient : BaseRestClient
    {
        public static T Get<T>(string url, Dictionary<string, string> headers) => RestClient.Exchange<T>(url, HttpMethod.Get, headers, (object) null);

        public static T Post<T>(string url, Dictionary<string, string> headers, object request) => RestClient.Exchange<T>(url, HttpMethod.Post, headers, request);

        public static T Post<T>(string url, Dictionary<string, string> headers) => RestClient.Exchange<T>(url, HttpMethod.Post, headers, (object) null);

        public static T Put<T>(string url, Dictionary<string, string> headers, object request) => RestClient.Exchange<T>(url, HttpMethod.Put, headers, request);

        public static void Delete<T>(string url, Dictionary<string, string> headers) => RestClient.Exchange<T>(url, HttpMethod.Delete, headers, (object) null);

        private static T Exchange<T>(
            string url,
            HttpMethod httpMethod,
            Dictionary<string, string> headers,
            object request)
        {
            try
            {
                HttpRequestMessage request1 = BaseRestClient.BuildHttpRequestMessage(url, httpMethod, headers, request);
                HttpResponseMessage result = BaseRestClient.HttpClient.SendAsync(request1).Result;
                var originalRequestString = request1.Content.ReadAsStringAsync().Result;
                var originalResponseString = result.Content.ReadAsStringAsync().Result;
                return BaseRestClient.HandleResponse<T>(result, result.Content.ReadAsByteArrayAsync().Result);
            }
            catch (BaseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new BaseException(ex);
            }
        }
    }


    
