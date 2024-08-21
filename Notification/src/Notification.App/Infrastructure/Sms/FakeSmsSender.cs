using Notification.App.Application.Common.Interfaces;
using Notification.App.Application.Common.Models;

namespace Notification.App.Infrastructure.Sms;

public class FakeSmsSender(ILogger<FakeSmsSender> _logger) : ISmsSender
{
    public Task<Result> SendSmsAsync(List<string> to, string from, string subject, string body)
    {
        _logger.LogInformation("Not actually sending an email to {to} from {from} with subject {subject}", to, from, subject);
        return Task.FromResult(Result.Success());
    }
}