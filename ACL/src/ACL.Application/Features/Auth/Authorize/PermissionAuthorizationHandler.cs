using System.Security.Claims;
using ACL.Application.Common;
using ACL.Application.Domain.Ports.Repositories.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ACL.Application.Features.Auth.Authorize
{
    public class PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory)
        : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement authorizationRequirement)
        {

            if (context.IsPermissible())
            {
                using IServiceScope scope = serviceScopeFactory.CreateScope();
                
                IAclUserRepository userRepo =
                    scope.ServiceProvider.GetRequiredService<IAclUserRepository>();
                
                var userId = Convert.ToUInt32(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
#pragma warning disable CS8604 // Possible null reference argument.
                var routeName = (context.Resource as HttpContext).GetRouteName();
                
                var user = userRepo.GetUserWithPermissionAsync(userId).Result;

                if (user != null && user.IsPermitted(routeName))
                {
                    context.Succeed(authorizationRequirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
