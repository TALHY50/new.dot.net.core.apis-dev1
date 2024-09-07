using ACL.Business.Application;
using ACL.Business.Application.Features.Auth;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure;
using ACL.Business.Infrastructure.Middlewares;
using ACL.Business.Infrastructure.Middlewares.Extensions;
using ACL.Business.Infrastructure.Persistence.Repositories;
using ACL.Business.Presentation;
using ACL.Web.Presentation;
using FastEndpoints;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using SharedKernel.Main.Application;
using SharedKernel.Main.Infrastructure;
using SharedKernel.Main.Infrastructure.MiddleWares;
using SharedKernel.Main.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSharedKernelApplication();
builder.Services.AddSharedKernelInfrastructure(builder.Configuration, builder.Environment, builder.Host);
builder.Services.AddSharedKernelPresentation();

builder.Services.AddACLBusinessApplication(builder.Configuration, builder.Environment, builder.Host);
builder.Services.AddACLBusinessInfrastructure(builder.Configuration, builder.Environment, builder.Host);
builder.Services.AddACLBusinessPresentation(builder.Configuration, builder.Environment, builder.Host);

builder.Services.AddACLWebPresentation(builder.Configuration, builder.Environment, builder.Host);
builder.Services.AddScoped<IRefreshTokenUseCase, RefreshTokenService>();
//builder.Services.AddScoped<IIdentity, IdentityService>(); // Assuming IdentityService implements IIdentity
builder.Services.AddScoped<IUserRepository, UserRepository>(); // Register your UserRepository
builder.Services.AddScoped<IUserSettingRepository, UserSettingRepository>(); // Register your UserSettingRepository
builder.Services.AddScoped<CreateJwtTokenCommandHandler>();

builder.Services.AddIdentityServer(options =>
{
    options.EmitStaticAudienceClaim = true;
})
    .AddInMemoryApiResources(IdentityServerConfig.GetApiResources()) // Load API resources
    .AddInMemoryClients(IdentityServerConfig.GetClients())           // Load clients
    .AddInMemoryApiScopes(IdentityServerConfig.GetApiScopes())       // Load API scopes
    .AddDeveloperSigningCredential();  // Developer signing credentials for testing purposes

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "api1");
    });
});

var app = builder.Build();
{
    app.UseAuthentication()
        .UseSwagger()
        .UseSwaggerUI(options => { options.DefaultModelsExpandDepth(-1); })
        .UseMiddleware<RequestResponseLoggingMiddleware>()
        .UseSerilogRequestLogging()
        .UseMiddleware<GlobalExceptionHandlerMiddleware>()
        .UseRouting()
        .UseAuthorization()
        .UseEndpoints(endpoints => { endpoints.MapControllers(); })
        .UseFileServer()
        .UseHttpsRedirection()
        .UseCors(builder => { 
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader(); 
        });

    //app.MapIdentityApi<User>();
    /*app.MapIdentityApiFilterable<User>(new IdentityApiEndpointRouteBuilderOptions()
    {
        ExcludeRegisterPost = true,
        ExcludeLoginPost = true,
        ExcludeRefreshPost = true,
        ExcludeConfirmEmailGet = true,
        ExcludeResendConfirmationEmailPost = true,
        ExcludeForgotPasswordPost = true,
        ExcludeResetPasswordPost = true,
        // setting ExcludeManageGroup to false will disable
        // 2FA and both Info Actions
        ExcludeManageGroup = true,
        Exclude2faPost = true,
        ExcludegInfoGet = true,
        ExcludeInfoPost = true,
    });*/
    app.Run();
}



public static class IdentityServerConfig
{
    // Define the API resources
    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            new ApiResource("api1", "My API")
        };
    }

    // Define the API scopes
    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new List<ApiScope>
        {
            new ApiScope("api1", "My API")
        };
    }

    // Define the clients (e.g., web apps, mobile apps)
    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>
        {
            new Client
            {
                ClientId = "client1",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "api1" }
            }
        };
    }
}
