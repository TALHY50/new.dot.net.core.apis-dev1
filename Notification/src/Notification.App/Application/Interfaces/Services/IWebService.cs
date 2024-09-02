using SharedKernel.Main.Application.Models;

namespace Notification.App.Application.Interfaces.Services;

public interface IWebService
{
    public Task<Result> SendWebhookAsync(List<string> urls, string content);
}