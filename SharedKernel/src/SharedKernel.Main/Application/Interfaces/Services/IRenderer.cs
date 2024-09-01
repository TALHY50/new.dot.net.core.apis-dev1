namespace SharedKernel.Main.Application.Interfaces.Services;

public interface IRenderer
{
    Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);

}