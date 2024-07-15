namespace Notification.RazorTemplateEngine.Services;

public interface ITemplateExecutionEngine
{
    Task<string> RenderTemplate(string templatePath, object viewModel);

    Task<string> RenderTemplate(string templatePath, string jsonData);
}