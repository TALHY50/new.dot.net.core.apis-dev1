using ACL.Business.Application;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure;
using ACL.Business.Infrastructure.Middlewares;
using ACL.Business.Presentation;
using ACL.Web.Presentation;
using Microsoft.AspNetCore.Identity;
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
    
    app.MapIdentityApi<User>();
    app.Run();
}

