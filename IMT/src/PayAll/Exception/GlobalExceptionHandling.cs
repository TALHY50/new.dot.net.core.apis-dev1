
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using exception = System.Exception;

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
                await HandleExceptionAsync(context, ex,null);
            }
            catch (exception ex)
            {
                await HandleExceptionAsync(context, null,ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, PayAllException exception, exception ex)
        {
            string message = string.Empty;
            int ErrorCode = 0;
            if (exception != null)
            {
                message = exception.Message;
                ErrorCode = Convert.ToInt16(exception.ErrorCode);
            }
            if(ex != null)
            {
                message = ex.Message;
                ErrorCode = context.Response.StatusCode;
            }
            var payload = JsonSerializer.Serialize(message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ErrorCode;
            
            await context.Response.WriteAsync(payload);

        }
    }

   

}
