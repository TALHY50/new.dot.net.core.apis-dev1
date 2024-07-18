//using System.ComponentModel;
//using System.Text;
//using Microsoft.AspNetCore.Http;
//using Newtonsoft.Json;
//using App.Interfaces;
//using App.Utilities;

//namespace App.Services;

//public class ResponseHandler
//{
    
    
//    public const string RESPONSE_METHOD_TYPE_POST = "POST";
//    public const string RESPONSE_METHOD_TYPE_GET = "GET";
//    public const string RESPONSE_METHOD_TYPE_JSON = "JSON";
//    private readonly IUnitOfWork _unitOfWork;

//    public ResponseHandler(IUnitOfWork unitOfWork)
//    {
//        _unitOfWork = unitOfWork;
//    }

//    public Task RedirectOrRespond<T>(string method, T response, string url = null)
//    {
//        switch (method.ToUpper())
//        {
//            case RESPONSE_METHOD_TYPE_POST:
//                return this.RedirectPost(url, response);
//            case RESPONSE_METHOD_TYPE_GET:
//                return this.RedirectGet(url, response);
//            case RESPONSE_METHOD_TYPE_JSON:
//                return this.RespondJson(response);
            
//            default:
//                return this.RespondJson(response);
                
            
//        }
        
//    }

//    public Task RedirectPost<T>(string postbackUrl, T response)
//    {
//        if (string.IsNullOrEmpty(postbackUrl))
//        {
//            return RespondJson(("Invalid Url"));

//        }
//        _unitOfWork.HttpContextAccessor.HttpContext.Response.Clear();

//        var sb = new Http().BuildForm(postbackUrl, response);

//       return _unitOfWork.HttpContextAccessor.HttpContext.Response.WriteAsync(sb.ToString());
        
//    }
    
    
//    public Task RedirectPost(StringBuilder response)
//    {
//        _unitOfWork.HttpContextAccessor.HttpContext.Response.Clear();
        
//        return _unitOfWork.HttpContextAccessor.HttpContext.Response.WriteAsync(response.ToString());
        
//    }
    

//    public Task RedirectGet<T>(string getbackUrl, T response)
//    {
//        if (string.IsNullOrEmpty(getbackUrl))
//        {
//            return RespondJson("Invalid Url");

//        }
//        var context = _unitOfWork.HttpContextAccessor.HttpContext;

//        if (context == null)
//        {
//            throw new InvalidOperationException("HttpContext is not available.");
//        }

//        getbackUrl = new Http().BuildRedirectUrl(getbackUrl, response);

//        // Asynchronously redirect to the constructed URL
//        context.Response.Redirect(getbackUrl);
        
//        return context.Response.CompleteAsync();
//    }

//    public Task RespondJson<T>(T response, int httpCode = 200, JsonSerializerSettings? settings = null)
//    {
//        var context = _unitOfWork.HttpContextAccessor.HttpContext;

//        if (context == null)
//        {
//            throw new InvalidOperationException("HttpContext is not available.");
//        }

//        if (settings == null){
//            settings = new JsonSerializerSettings
//            {
//                NullValueHandling = NullValueHandling.Include
//            };
//        }
        

//        // Convert the dictionary to a JSON string
//        var json = Json.Serialize(response as object,  settings);

//        // Set the response content type to JSON
//        context.Response.ContentType = "application/json";
//        context.Response.HttpContext.Response.StatusCode = httpCode;

//        // Write the JSON response to the response stream
//        return context.Response.WriteAsync(json); 
//    }
//}

namespace SharedKernel.Infrastructure.Services;