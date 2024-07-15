namespace Notification.Main.Application.Common.Interfaces;

public interface ITemplateExecutionEngine
{
    Task<string> RenderTemplate(string templatePath, object viewModel);

    Task<string> RenderTemplate(string templatePath, string jsonData);
}