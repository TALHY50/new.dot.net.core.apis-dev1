using Notification.Main.Application.Common.Models;

namespace Notification.Main.Application.Common.Interfaces;

public interface ISmsSender
{
    public Task<Result> SendSmsAsync(List<string> to, string from, string subject, string body);
}