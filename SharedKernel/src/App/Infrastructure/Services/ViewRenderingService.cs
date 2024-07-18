using App.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace App.Infrastructure.Services;

public class ViewRenderingService : IViewRenderingService
{
    private readonly ICompositeViewEngine _viewEngine;
    private readonly ITempDataProvider _tempDataProvider;
    private readonly IServiceProvider _serviceProvider;
    private readonly IRazorViewEngine _razorViewEngine;

    public ViewRenderingService(ICompositeViewEngine viewEngine, ITempDataProvider tempDataProvider,
        IServiceProvider serviceProvider, IRazorViewEngine razorViewEngine)
    {
        _viewEngine = viewEngine;
        _tempDataProvider = tempDataProvider;
        _serviceProvider = serviceProvider;
        _razorViewEngine = razorViewEngine;
    }

    public string RenderToStringAsync(string pathToView, object model)
    {
        var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
        var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

        using (var sw = new StringWriter())
        {
            var viewResult = _razorViewEngine.GetView(null, pathToView, false);
            if (viewResult.View == null)
            {
                throw new ArgumentNullException($"{pathToView} does not match any available view");
            }

            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };

            var viewContext = new ViewContext(
                actionContext,
                viewResult.View,
                viewDictionary,
                new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                sw,
                new HtmlHelperOptions()
            );

            viewResult.View.RenderAsync(viewContext);

            return sw.ToString();
        }
    }
}