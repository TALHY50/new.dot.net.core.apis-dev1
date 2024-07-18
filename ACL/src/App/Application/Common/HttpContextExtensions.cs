using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace App.Application.Common;

public static class HttpContextExtensions
{
    public static string GetRouteName(this HttpContext httpContext)
    {
        var endpoint = httpContext.GetEndpoint() as RouteEndpoint;
        var routeNameMetadata = endpoint?.Metadata.OfType<RouteNameMetadata>().SingleOrDefault();
        var routeName = routeNameMetadata?.RouteName;

#pragma warning disable CS8603 // Possible null reference return.
        return routeName;
#pragma warning restore CS8603 // Possible null reference return.
    }

    public static bool IsPermissible(this AuthorizationHandlerContext context)
    {
        return context.User.Identity != null
               && context.User.Identity.IsAuthenticated
               && context.User.HasClaim(c => c.Type == ClaimTypes.NameIdentifier);

    }
    
}