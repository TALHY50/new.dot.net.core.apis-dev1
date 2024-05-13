using System.Security.Claims;
using ACL.Application.Ports.Services;
using ACL.Database.Models;
using ACL.Domain;
using ACL.Domain.Permissions;
using ACL.Infrastructure.Services.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace ACL.Infrastructure.Security
{
    public class PermissionHandler(IServiceScopeFactory serviceScopeFactory)
        : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {

            if (context.IsPermissible())
            {
                using IServiceScope scope = serviceScopeFactory.CreateScope();

                IPermissionService permissionService =
                    scope.ServiceProvider.GetRequiredService<IPermissionService>();


                var userId = Convert.ToUInt32(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var version = Convert.ToUInt32(context.User.FindFirst(JwtService.VersionClaimType)?.Value);
                var routeName = (context.Resource as HttpContext).GetRouteName();
                
                var user = permissionService.GetUserAsync(userId, version).Result;

                if (user != null && user.IsPermitted(routeName))
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
