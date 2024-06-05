
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace IMT.PayAll.Exception
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (PayAllException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, PayAllException exception)
        {

            var payload = JsonSerializer.Serialize(exception.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception.ErrorCode!= null ? Convert.ToInt16(exception.ErrorCode) : context.Response.StatusCode;
            
            await context.Response.WriteAsync(payload);

        }
    }

   

}
