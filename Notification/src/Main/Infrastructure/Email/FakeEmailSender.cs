using Microsoft.Extensions.Logging;

using Notification.Main.Application.Common.Interfaces;

namespace Notification.Main.Infrastructure.Email;

public class FakeEmailSender(ILogger<FakeEmailSender> _logger) : IEmailSender
{
    public Task SendEmailAsync(List<string> to, string from, string subject, string body)
    {
        _logger.LogInformation("Not actually sending an email to {to} from {from} with subject {subject}", to, from, subject);
        return Task.CompletedTask;
    }
}