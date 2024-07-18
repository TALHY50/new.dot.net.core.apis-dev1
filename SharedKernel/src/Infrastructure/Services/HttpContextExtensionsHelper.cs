using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace SharedKernel.Infrastructure.Services;

#pragma warning disable CS8600 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Possible null reference argument.
public static class HttpContextExtensions
{
    public static object? GetBrandSession(this IHttpContextAccessor httpContextAccessor, string key, string reference = "")
    {
        if (!string.IsNullOrEmpty(reference))
        {
            key = $"{key}_{reference}";
        }

        var session = httpContextAccessor.HttpContext.Session;
        session.TryGetValue(key, out byte[] valueBytes);
        if (valueBytes != null)
        {
            var valueString = Encoding.UTF8.GetString(valueBytes);
            return valueString;
        }

        return null;
    }


    public static void SetBrandSession(this IHttpContextAccessor httpContextAccessor, string key, object value, string reference="")
    {
        if (!string.IsNullOrEmpty(reference))
        {
            key = $"{key}_{reference}";
        }
    
        var session = httpContextAccessor.HttpContext.Session;
        session.Set(key,Encoding.UTF8.GetBytes(JsonSerializer.Serialize( value)));
    }
}