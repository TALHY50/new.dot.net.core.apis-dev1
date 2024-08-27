using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;

namespace SharedKernel.Main.Infrastructure.Security
{
    public class PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory)
        : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement authorizationRequirement)
        {

            if (context.IsPermissible())
            {
                using IServiceScope scope = serviceScopeFactory.CreateScope();
                
                IUserRepository userRepo =
                    scope.ServiceProvider.GetRequiredService<IUserRepository>();
                
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
