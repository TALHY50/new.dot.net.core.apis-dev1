using System.Security.Claims;
using ACL.Infrastructure.Services.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace ACL.Infrastructure.Security;

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