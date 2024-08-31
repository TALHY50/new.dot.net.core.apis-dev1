using Microsoft.OpenApi.Models;

using Notification.App;
using Notification.App.Application;
using Notification.App.Infrastructure;
using Notification.App.Presentation;

using SharedKernel.Main;
using SharedKernel.Main.Application;
using SharedKernel.Main.Infrastructure;
using SharedKernel.Main.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSharedKernelApplication();
builder.Services.AddSharedKernelInfrastructure(builder.Configuration, builder.Environment, builder.Host);
builder.Services.AddSharedKernelPresentation();

builder.Services.AddNotificationApplication();
builder.Services.AddNotificationInfrastructure(builder.Configuration, builder.Environment, builder.Host);
builder.Services.AddNotificationPresentation(builder.Configuration);
var app = builder.Build();
{
    app.UseSwagger(); 
    app.UseSwaggerUI(options => { 
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); 
        options.RoutePrefix = string.Empty; 
    }); 
    app.UseCors(); 
    app.UseHttpsRedirection(); 
    app.UseAuthorization(); 
    app.MapControllers(); 
    app.Run(); 
}

