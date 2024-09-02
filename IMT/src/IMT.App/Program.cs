using ACL.Business.Application;
using ACL.Business.Infrastructure;
using ACL.Business.Presentation;
using IMT.App.Application;
using IMT.App.Infrastructure;
using IMT.App.Presentation;
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


builder.Services.AddIMTApplication();
builder.Services.AddIMTInfrastructure(builder.Configuration);
builder.Services.AddIMTPresentation();

var app = builder.Build();
app.UseSwagger()
    .UseSwaggerUI(options => { 
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); 
        options.RoutePrefix = string.Empty; })
    .UseCors()
    .UseHttpsRedirection()
    .UseAuthorization();


app.MapControllers();

app.Run();
