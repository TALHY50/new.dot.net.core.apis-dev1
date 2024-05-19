using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ACL.Application.Common;

public static class HttpContextExtensions
{
    public static string GetRouteName(this HttpContext httpContext)
    {
        var endpoint = httpContext.GetEndpoint() as RouteEndpoint;
        var routeNameMetadata = endpoint?.Metadata.OfType<RouteNameMetadata>().SingleOrDefault();
        var routeName = routeNameMetadata?.RouteName;

        return routeName;
    }

    public static bool IsPermissible(this AuthorizationHandlerContext context)
    {
        return context.User.Identity != null
               && context.User.Identity.IsAuthenticated
               && context.User.HasClaim(c => c.Type == ClaimTypes.NameIdentifier);

    }
    
}