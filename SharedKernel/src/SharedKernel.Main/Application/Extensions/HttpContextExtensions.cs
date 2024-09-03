using System.Text;
using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Application.Extensions;

public static class HttpContextExtensions
{
    /// <summary>
    /// Asynchronously reads the request body as a string.
    /// </summary>
    /// <param name="context">The HttpContext instance.</param>
    /// <returns>A task that represents the asynchronous read operation. The task result contains the request body as a string.</returns>
    public static async Task<string> RequestBodyAsync(this HttpContext context)
    {
        context.Request.EnableBuffering();
        context.Request.Body.Position = 0;

        using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
        var body = await reader.ReadToEndAsync();

        context.Request.Body.Position = 0;

        return body;
    }
    
    public static string? RequestBodyFromItem(this HttpContext context)
    {
       
        using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
        var body = context.Items["RequestBody"] ?? "";
        return body.ToString();
    }
}