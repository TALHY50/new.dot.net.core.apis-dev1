namespace Notification.Renderer.Services;

public interface IRenderer
{
    Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);

    Task<string> GetSmsText<TModel>(TModel model, string lang);
}