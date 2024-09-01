namespace SharedKernel.Main.Application.Interfaces.Services;

public interface IViewRenderingService
{

    public string RenderToStringAsync(string viewName, object model);
}