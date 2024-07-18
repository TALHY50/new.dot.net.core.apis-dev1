using System.Net;
using System.Text;
using Newtonsoft.Json;
using PayAll.Common;
using PayAll.Exception;
using PayAll.Response.Common;

namespace PayAll.Net
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
            return typeof(T) == typeof(byte[])? HandleByteArrayResponse<T>(httpResponseMessage, content): HandleJsonResponse<T>(httpResponseMessage, content);
        }
       
        private static T HandleJsonResponse<T>(HttpResponseMessage httpResponseMessage, byte[] content)
        {
            var contentString = Encoding.UTF8.GetString(content);
            RequireSuccess<T>(httpResponseMessage, contentString);
            var apiResponse = JsonConvert.DeserializeObject<T>(contentString, PayAllJsonSerializerSettings.Settings);
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
           
            if(httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new PayAllException(((int)httpResponseMessage.StatusCode).ToString(), httpResponseMessage.StatusCode.ToString(), content);
            }

            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(content, PayAllJsonSerializerSettings.Settings);
            if (errorResponse != null)
            {
                throw new PayAllException(((int)httpResponseMessage.StatusCode).ToString(), errorResponse.message, errorResponse);
            }
        }

        private static StringContent PrepareContent(object request)
        {
            if (request == null) return null;
            var body = JsonConvert.SerializeObject(request, PayAllJsonSerializerSettings.Settings);
            return new StringContent(body, Encoding.UTF8, "application/json");
        }

        protected static HttpResponse<T> HandleResponse<T>(HttpResponseMessage httpResponse,string content)
        {
            var apiResponse = JsonConvert.DeserializeObject<T>(httpResponse.Content.ReadAsStringAsync().Result, PayAllJsonSerializerSettings.Settings);

            return new HttpResponse<T>
            {
                StatusCode = (int)httpResponse.StatusCode,
                StatusMessage = httpResponse.StatusCode.ToString(),
                ReasonPhrase = httpResponse.ReasonPhrase,
                Version = httpResponse.Version.ToString(),
                Headers = new Dictionary<string, string>(),
                Content = httpResponse.Content != null ? httpResponse.Content.ReadAsStringAsync().Result : null,
                Data = apiResponse
            };
        }
    }
}