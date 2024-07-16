using Notification.App.Application.Common.Models;

namespace Notification.App.Application.Common.Interfaces;

public interface IWebService
{
    public Task<Result> SendWebhookAsync(List<string> urls, string content);
}