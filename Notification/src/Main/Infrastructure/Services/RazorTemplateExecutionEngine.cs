using System.Reflection;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Notification.Main.Application.Common.Interfaces;
using Notification.Main.Application.Common.Models;
using RazorLight;

namespace Notification.Main.Infrastructure.Services;

public class RazorTemplateExecutionEngine : ITemplateExecutionEngine
{
    private readonly IRazorViewEngine _viewEngine;
    private readonly ITempDataProvider _tempDataProvider;
    private readonly IServiceProvider _serviceProvider;
    private readonly RazorLightEngine _engine;
    private static readonly string RootNamespace = "Notification.Main.Infrastructure.Templates";

    public RazorTemplateExecutionEngine(
        IRazorViewEngine viewEngine,
        ITempDataProvider tempDataProvider,
        IServiceProvider serviceProvider)
    {
        _engine = new RazorLightEngineBuilder()
            .UseEmbeddedResourcesProject(Assembly.GetExecutingAssembly(), RootNamespace)
            .UseMemoryCachingProvider()
            .Build();

        _viewEngine = viewEngine;
        _tempDataProvider = tempDataProvider;
        _serviceProvider = serviceProvider;
    }

    public async Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model)
    {
        var actionContext = GetActionContext();
        var view = FindView(actionContext, viewName);

        await using var output = new StringWriter();
        var viewContext = new ViewContext(
            actionContext,
            view,
            new ViewDataDictionary<TModel>(
                metadataProvider: new EmptyModelMetadataProvider(),
                modelState: new ModelStateDictionary())
            {
                Model = model,
            },
            new TempDataDictionary(
                actionContext.HttpContext,
                _tempDataProvider),
            output,
            new HtmlHelperOptions());

        await view.RenderAsync(viewContext);

        return output.ToString();
    }

    public async Task<string> RenderTemplate(string templatePath, string jsonData)
    {
        string html = string.Empty;

        var viewModelType = TemplateMap.GetViewModelType(templatePath);
        if (viewModelType == null)
        {
            throw new ArgumentException("Template not registered or ViewModel type not found for the specified template path.");
        }

        var viewModel = JsonConvert.DeserializeObject(jsonData, viewModelType);

        if (viewModel != null)
        {
            html = await RenderTemplate(templatePath, viewModel).ConfigureAwait(false);
        }

        return html;
    }

    public async Task<string> RenderTemplate(string templatePath, object viewModel)
    {
        string emailBody = await _engine.CompileRenderAsync(templatePath, viewModel).ConfigureAwait(false);
        return emailBody;
    }

    private IView FindView(ActionContext actionContext, string viewName)
    {
        var getViewResult = _viewEngine.GetView(executingFilePath: null, viewPath: viewName, isMainPage: true);
        if (getViewResult.Success)
        {
            return getViewResult.View;
        }

        var findViewResult = _viewEngine.FindView(actionContext, viewName, isMainPage: true);
        if (findViewResult.Success)
        {
            return findViewResult.View;
        }

        var searchedLocations = getViewResult.SearchedLocations.Concat(findViewResult.SearchedLocations);
        var errorMessage = string.Join(
            Environment.NewLine,
            new[] { $"Unable to find view '{viewName}'. The following locations were searched:" }.Concat(searchedLocations));

        throw new InvalidOperationException(errorMessage);
    }

    private ActionContext GetActionContext()
    {
        var httpContext = new DefaultHttpContext
        {
            RequestServices = _serviceProvider,
        };
        return new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
    }
}