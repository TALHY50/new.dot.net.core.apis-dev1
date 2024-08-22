namespace SharedKernel.Main.Application.Common.Interfaces.Services;

public interface IViewRenderingService
{

    public string RenderToStringAsync(string viewName, object model);
}