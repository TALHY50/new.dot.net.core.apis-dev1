using ACL.Business.Application;
using ACL.Business.Infrastructure;
using ACL.Business.Infrastructure.Middlewares;
using ACL.Business.Presentation;
using Serilog;
using SharedKernel.Main.Infrastructure.MiddleWares;
using DependencyInjection = ACL.Web.Presentation.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplication(builder.Configuration, builder.Environment);
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment, builder.Host);
builder.Services.AddPresentation(builder.Configuration, builder.Environment);
DependencyInjection.AddPresentation(builder.Services, builder.Configuration, builder.Environment);

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

    app.Run();
}

