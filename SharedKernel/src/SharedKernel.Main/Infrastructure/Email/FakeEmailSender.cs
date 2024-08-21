using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Common.Interfaces;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Application.Common.Models;

namespace SharedKernel.Main.Infrastructure.Email;

public class FakeEmailSender(ILogger<FakeEmailSender> _logger) : IEmailSender
{
    public Task<Result> SendEmailAsync(List<string> to, string from, string subject, string body)
    {
        _logger.LogInformation("Not actually sending an email to {to} from {from} with subject {subject}", to, from, subject);
        return Task.FromResult(Result.Success());
    }
}