using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MySqlConnector;
using SharedLibrary.Response;
using System.Net;
using System.Text.Json;

namespace SharedLibrary.CustomMiddleWare
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        BaseResponse aclResponse = new BaseResponse();
        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    aclResponse.Message = "The requested resource is not found.";
                    aclResponse.StatusCode = context.Response.StatusCode;

                    var exResult = JsonSerializer.Serialize(aclResponse);
                    await context.Response.WriteAsync(exResult);
                }

                if (context.Response.StatusCode == StatusCodes.Status405MethodNotAllowed)
                {
                    aclResponse.Message = "The requested method not supported.";
                    aclResponse.StatusCode = context.Response.StatusCode;

                    var exResult = JsonSerializer.Serialize(aclResponse);
                    await context.Response.WriteAsync(exResult);
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //var statusCode = HttpStatusCode.InternalServerError; // Default to 500

            //// You can add more specific exception handling here if needed
            //var errorMessage = exception.Message;

            //var response = new { message = errorMessage };
            //var payload = JsonSerializer.Serialize(response);

            //context.Response.ContentType = "application/json";
            //context.Response.StatusCode = (int)statusCode;

            //return context.Response.WriteAsync(payload);

            context.Response.ContentType = "application/json";
            switch (exception)
            {
                case MySqlException ex:
                    aclResponse.Message = ex.Message;
                    aclResponse.StatusCode = context.Response.StatusCode;
                    break;
                case ApplicationException ex:
                    aclResponse.Message = ex.Message;
                    aclResponse.StatusCode = context.Response.StatusCode;
                    break;
                case FileNotFoundException ex:
                    aclResponse.Message = ex.Message;
                    aclResponse.StatusCode = context.Response.StatusCode;
                    break;
                case NullReferenceException ex:
                    aclResponse.Message = ex.Message;
                    aclResponse.StatusCode = context.Response.StatusCode;
                    break;
                case InvalidOperationException ex:
                    aclResponse.Message = ex.Message;
                    aclResponse.StatusCode = context.Response.StatusCode;
                    break;
                default:
                    aclResponse.Message = "Internal Server Error, Please retry after sometime";
                    aclResponse.StatusCode = context.Response.StatusCode;
                    break;

            }
            var exResult = JsonSerializer.Serialize(aclResponse);
            await context.Response.WriteAsync(exResult);
        }
    }

    public static class GlobalExceptionHandlerMiddlewareExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }

}
