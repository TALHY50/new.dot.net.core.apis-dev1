using SharedKernel.Main.Application.Models;

namespace Notification.App.Application.Interfaces.Services;

public interface ISmsSender
{
    public Task<Result> SendSmsAsync(List<string> to, string from, string subject, string body);
}