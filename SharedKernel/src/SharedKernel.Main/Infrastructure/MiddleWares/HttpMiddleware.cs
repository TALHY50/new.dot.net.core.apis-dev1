namespace SharedKernel.Main.Infrastructure.MiddleWares;

using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public class HttpMiddleware
{
    private readonly RequestDelegate _next;

    public HttpMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.EnableBuffering();

        // Read the request body
        var bodyAsText = await new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true).ReadToEndAsync();
        context.Request.Body.Position = 0; // Reset the stream position

        if (!string.IsNullOrEmpty(bodyAsText))
        {
            try
            {
                // Deserialize the request body to the desired object type
                var requestObject = bodyAsText;

                // Store the deserialized object in HttpContext.Items to access it later
                context.Items["RequestBody"] = requestObject;
            }
            catch (JsonException)
            {
                // Handle JSON deserialization errors if necessary
                //context.Response.StatusCode = StatusCodes.Status400BadRequest;
                //await context.Response.WriteAsync("Invalid JSON format");
                await _next(context);
                return;
            }
        }

        // Call the next middleware in the pipeline
        await _next(context);
    }
}
