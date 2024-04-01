using Craftgate.Common;
using Craftgate.Exception;
using Craftgate.Response.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using SharedLibrary.Exceptions;

namespace SharedLibrary.Utilities;

  public abstract class BaseRestClient
  {
    protected static readonly HttpClient HttpClient;

    static BaseRestClient()
    {
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
      BaseRestClient.HttpClient = new HttpClient((HttpMessageHandler) new HttpClientHandler()
      {
        AllowAutoRedirect = false
      })
      {
        Timeout = TimeSpan.FromSeconds(150.0)
      };
    }

    protected static HttpRequestMessage BuildHttpRequestMessage(
      string url,
      HttpMethod httpMethod,
      Dictionary<string, string>? headers,
      object request)
    {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
      {
        Method = httpMethod,
        RequestUri = new Uri(url),
        Content = (HttpContent) BaseRestClient.PrepareContent(request)
      };

      if (headers != null)
      {
        foreach (KeyValuePair<string, string> header in headers)
          httpRequestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
      }

      return httpRequestMessage;
    }

    protected static T HandleResponse<T>(HttpResponseMessage httpResponseMessage, byte[] content) => !(typeof (T) == typeof (byte[])) ? BaseRestClient.HandleJsonResponse<T>(httpResponseMessage, content) : BaseRestClient.HandleByteArrayResponse<T>(httpResponseMessage, content);

    private static T HandleJsonResponse<T>(HttpResponseMessage httpResponseMessage, byte[] content)
    {
      string content1 = Encoding.UTF8.GetString(content);
     // BaseRestClient.RequireSuccess<T>(httpResponseMessage, content1);
      var response = Json.Derialize<T>(content1);
      return (response != null ? response : default (T)) ?? throw new InvalidOperationException();
    }

    private static T HandleByteArrayResponse<T>(
      HttpResponseMessage httpResponseMessage,
      byte[] content)
    {
      BaseRestClient.RequireSuccess<T>(httpResponseMessage, Encoding.UTF8.GetString(content));
      return (T) Convert.ChangeType((object) content, typeof (T));
    }

    private static void RequireSuccess<T>(HttpResponseMessage httpResponseMessage, string content)
    {
      if (httpResponseMessage.StatusCode < HttpStatusCode.BadRequest)
        return;
      var response = Json.Derialize<T>(content);
      if (response != null)
      {
        //ErrorResponse errors = response.Errors;
        //throw new BaseException(errors.ErrorCode, errors.ErrorDescription, errors.ErrorGroup);
      }
    }

    private static StringContent PrepareContent(object request) => request == null ? (StringContent) null : new StringContent(JsonConvert.SerializeObject(request, CraftgateJsonSerializerSettings.Settings), Encoding.UTF8, "application/json");
    
    
  }


