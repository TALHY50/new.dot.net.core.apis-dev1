using System.Net;
using System.Text;
using Newtonsoft.Json;
using Thunes.Common;
using Thunes.Exception;
using Thunes.Response.Common;

namespace Thunes.Net
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
        protected static T HandleResponse<T>(HttpResponseMessage httpResponseMessage, string content)
        {
            return HandleJsonResponse<T>(httpResponseMessage, content);
        }
        protected static object HandleObjectResponse<T>(HttpResponseMessage httpResponseMessage, string content)
        {
            var response = HandleJsonObjectResponse<T>(httpResponseMessage, content);
            var httpResponse = JsonConvert.SerializeObject(httpResponseMessage);
            var apiResponse = JsonConvert.DeserializeObject<T>(content, ThunesJsonSerializerSettings.Settings);
            return apiResponse;
        }

        private static T HandleJsonResponse<T>(HttpResponseMessage httpResponseMessage, string content)
        {
            RequireSuccess<T>(httpResponseMessage, content);

            var httpResponse = JsonConvert.SerializeObject(httpResponseMessage);
            var apiResponse = JsonConvert.DeserializeObject<Response<T>>((content != "") ? content : httpResponse, ThunesJsonSerializerSettings.Settings);

            if (apiResponse.Data == null)
            {
                apiResponse = new Response<T>();
                //apiResponse.Errors = new ErrorsResponse();
                //apiResponse.Errors.code = ((int)httpResponseMessage.StatusCode).ToString();
                //apiResponse.Errors.message = httpResponseMessage.ReasonPhrase ?? httpResponseMessage.StatusCode.ToString();
            }

            return apiResponse.Data;
        }
        private static Object HandleJsonObjectResponse<T>(HttpResponseMessage httpResponseMessage, string content)
        {
            RequireSuccess<T>(httpResponseMessage, content);

            var httpResponse = JsonConvert.SerializeObject(httpResponseMessage);
            var apiResponse = JsonConvert.DeserializeObject<Response<T>>((content != "") ? content : httpResponse, ThunesJsonSerializerSettings.Settings);

            if (apiResponse.Data == null)
            {
                apiResponse = new Response<T>();
                //apiResponse.Errors = new ErrorsResponse();
                //apiResponse.Errors.code = ((int)httpResponseMessage.StatusCode).ToString();
                //apiResponse.Errors.message = httpResponseMessage.ReasonPhrase ?? httpResponseMessage.StatusCode.ToString();
                return apiResponse.Errors;
            }

            return apiResponse.Data;
        }

        private static T HandleJsonResponse<T>(HttpResponseMessage httpResponseMessage, byte[] content)
        {
            var contentString = Encoding.UTF8.GetString(content);
            RequireSuccess<T>(httpResponseMessage, contentString);
            var apiResponse = JsonConvert.DeserializeObject<T>(contentString, ThunesJsonSerializerSettings.Settings);
            return apiResponse == null ? default : apiResponse;
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
            if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized || 
                httpResponseMessage.StatusCode == HttpStatusCode.BadRequest ||
                httpResponseMessage.StatusCode == HttpStatusCode.NotFound ||
                httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new ThunesException((int)httpResponseMessage.StatusCode, response.Errors);
            }
           
            // more condition will written below
        }

        private static StringContent PrepareContent(object request)
        {
            if (request == null) return null;
            var body = JsonConvert.SerializeObject(request, ThunesJsonSerializerSettings.Settings);
            return new StringContent(body, Encoding.UTF8, "application/json");
        }
    }
}