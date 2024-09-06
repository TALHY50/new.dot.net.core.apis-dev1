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
builder.Services.AddScoped<IRefreshTokenUseCase, RefreshTokenService>();
//builder.Services.AddScoped<IIdentity, IdentityService>(); // Assuming IdentityService implements IIdentity
builder.Services.AddScoped<IUserRepository, UserRepository>(); // Register your UserRepository
builder.Services.AddScoped<IUserSettingRepository, UserSettingRepository>(); // Register your UserSettingRepository
builder.Services.AddScoped<CreateJwtTokenCommandHandler>();

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

