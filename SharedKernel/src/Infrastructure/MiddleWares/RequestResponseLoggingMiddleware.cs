using System.Text;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace SharedKernel.Infrastructure.MiddleWares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await LogRequest(context);

            // Capture response data before the request completes
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                await LogResponse(context);

                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task LogRequest(HttpContext context)
        {
            context.Request.EnableBuffering();
            var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Seek(0, SeekOrigin.Begin);

            var log = new StringBuilder();
            log.AppendLine($"[Request] {context.Request.Method}: {context.Request.Path}");
            log.AppendLine($"[Request Body] {requestBody}");

            Log.Information(log.ToString());
        }

        private async Task LogResponse(HttpContext context)
        {
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            var log = new StringBuilder();
            log.AppendLine($"[Response] {context.Request.Method}: {context.Request.Path}");
            log.AppendLine($"[Response Body] {responseBody}");

            Log.Information(log.ToString());
        }
    }
}
