namespace App.Application.Interfaces;

public interface IViewRenderingService
{

    public string RenderToStringAsync(string viewName, object model);
}