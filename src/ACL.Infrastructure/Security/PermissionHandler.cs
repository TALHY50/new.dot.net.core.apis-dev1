﻿using System.Security.Claims;
using ACL.Application.Ports.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

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
                var routeName = (context.Resource as HttpContext).GetRouteName();
                
                var user = permissionService.GetUserAsync(userId).Result;

                if (user != null && user.IsPermitted(routeName))
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}