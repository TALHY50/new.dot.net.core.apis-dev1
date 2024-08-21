using SharedKernel.Main.Application.Common.Common.Interfaces;
using SharedKernel.Main.Application.Common.Common.Models;

namespace Notification.App.Infrastructure.Sms;

public class FakeSmsSender(ILogger<FakeSmsSender> _logger) : ISmsSender
{
    public Task<Result> SendSmsAsync(List<string> to, string from, string subject, string body)
    {
        _logger.LogInformation("Not actually sending an email to {to} from {from} with subject {subject}", to, from, subject);
        return Task.FromResult(Result.Success());
    }
}