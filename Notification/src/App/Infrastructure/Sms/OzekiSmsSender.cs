using Notification.App.Application.Common.Interfaces;
using Notification.App.Application.Common.Models;

namespace Notification.Main.Infrastructure.Sms;

public class OzekiSmsSender(ILogger<OzekiSmsSender> _logger, SmsProviderConfiguration _provider) : ISmsSender
{
    public Task<Result> SendSmsAsync(List<string> to, string from, string subject, string body)
    {
        _logger.LogInformation(_provider.Hostname);
        _logger.LogInformation("Not actually sending an email to {to} from {from} with subject {subject}", to, from, subject);
        return Task.FromResult(Result.Success());
    }
}