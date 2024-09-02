using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SharedKernel.Main.Presentation;

namespace ACL.Business.Presentation;

public static class ACLPresentationDependencyInjection
{
    public static IServiceCollection AddACLBusinessPresentation(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment, ConfigureHostBuilder builderHost)
    {
        return services;
    }
}