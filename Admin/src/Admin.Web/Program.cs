using ACL.Business.Application;
using ACL.Business.Infrastructure;
using ACL.Business.Presentation;
using Admin.Web.Application;
using Admin.Web.Infrastructure;
using Admin.Web.Presentation;
using SharedBusiness.Main;
using SharedKernel.Main.Application;
using SharedKernel.Main.Infrastructure;
using SharedKernel.Main.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSharedKernelApplication();
builder.Services.AddSharedKernelInfrastructure(builder.Configuration, builder.Environment, builder.Host);
builder.Services.AddSharedKernelPresentation();

builder.Services.AddSharedBusinessApplication();
builder.Services.AddSharedBusinessInfrastructure(builder.Configuration, builder.Environment, builder.Host);
builder.Services.AddSharedBusinessPresentation();

builder.Services.AddACLBusinessApplication(builder.Configuration, builder.Environment, builder.Host);
builder.Services.AddACLBusinessInfrastructure(builder.Configuration, builder.Environment, builder.Host);
builder.Services.AddACLBusinessPresentation(builder.Configuration, builder.Environment, builder.Host);

builder.Services.AddAdminApplication(builder.Configuration, builder.Environment, builder.Host);
builder.Services.AddAdminInfrastructure(builder.Configuration, builder.Environment, builder.Host);
builder.Services.AddAdminPresentation(builder.Configuration, builder.Environment, builder.Host);

var app = builder.Build();
{
    app.UseSwagger()
        .UseSwaggerUI(options => {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        })
        .UseCors()
        .UseHttpsRedirection()
        .UseAuthorization();
    app.UseSharedKernelInfrastructure();
    app.MapControllers();
    app.Run();
}
