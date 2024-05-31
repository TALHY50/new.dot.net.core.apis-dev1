using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using IMT.Thunes.Common;
using IMT.Thunes.Exception;
using IMT.Thunes.Response.Common;
using Newtonsoft.Json;
using _exception = System.Exception;

namespace IMT.Thunes.Net
{
    public abstract class BaseRestClient
    {
        protected static readonly HttpClient HttpClient;

        static BaseRestClient()
        {
#if !NETSTANDARD1_3
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
#endif
            var handler = new HttpClientHandler { AllowAutoRedirect = false };
            HttpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(150)
            };
        }

        protected static HttpRequestMessage BuildHttpRequestMessage(string url, HttpMethod httpMethod, Dictionary<string, string> headers, object request)
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(url),
                Content = PrepareContent(request)
            };
            foreach (var header in headers) requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
            return requestMessage;
        }

        protected static T HandleResponse<T>(HttpResponseMessage httpResponseMessage, byte[] content)
        {
            return typeof(T) == typeof(byte[])
                ? HandleByteArrayResponse<T>(httpResponseMessage, content)
                : HandleJsonResponse<T>(httpResponseMessage, content);
        }

        private static T HandleJsonResponse<T>(HttpResponseMessage httpResponseMessage, byte[] content)
        {
            var contentString = Encoding.UTF8.GetString(content);
            RequireSuccess<T>(httpResponseMessage, contentString);
            var apiResponse = JsonConvert.DeserializeObject<Response<T>>(contentString, ThunesJsonSerializerSettings.Settings);
            return apiResponse == null ? default : apiResponse.Data;
        }

        private static T HandleByteArrayResponse<T>(HttpResponseMessage httpResponseMessage, byte[] content)
        {
            RequireSuccess<T>(httpResponseMessage, Encoding.UTF8.GetString(content));
            return (T)Convert.ChangeType(content, typeof(T));
        }

        private static void RequireSuccess<T>(HttpResponseMessage httpResponseMessage, string content)
        {
            if (httpResponseMessage.StatusCode < HttpStatusCode.BadRequest) return;
            var response = JsonConvert.DeserializeObject<Response<T>>(content, ThunesJsonSerializerSettings.Settings);
            if (response != null && response.Errors != null)
            {
                var errorResponse = response.Errors;
                throw new ThunesException(errorResponse.ErrorCode, errorResponse.ErrorDescription, errorResponse.ErrorGroup);
            }
        }

        private static StringContent PrepareContent(object request)
        {
            if (request == null) return null;
            var body = JsonConvert.SerializeObject(request, ThunesJsonSerializerSettings.Settings);
            return new StringContent(body, Encoding.UTF8, "application/json");
        }
    }
}