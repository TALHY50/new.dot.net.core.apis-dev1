using Notification.App.Application.Common.Models;

namespace Notification.App.Application.Common.Interfaces;

public interface ISmsSender
{
    public Task<Result> SendSmsAsync(List<string> to, string from, string subject, string body);
}