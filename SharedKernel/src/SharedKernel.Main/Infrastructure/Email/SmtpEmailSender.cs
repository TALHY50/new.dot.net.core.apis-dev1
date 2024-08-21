using Microsoft.Extensions.Logging;
using MimeKit;
using SharedKernel.Main.Application.Common.Common.Interfaces;
using SharedKernel.Main.Application.Common.Common.Models;

namespace SharedKernel.Main.Infrastructure.Email;

public class SmtpEmailSender : IEmailSender
{
    private readonly MailserverConfiguration _mailserverConfiguration;
    private readonly ILogger<SmtpEmailSender> _logger;

    public SmtpEmailSender(
        ILogger<SmtpEmailSender> logger,
        MailserverConfiguration mailserverOptions)
    {
        _mailserverConfiguration = mailserverOptions;
        _logger = logger;
    }

    public async Task<Result> SendEmailAsync(List<string> to, string from, string subject, string body)
    {
        _logger.LogWarning("Sending email to {to} from {from} with subject {subject} using {type}.", to, from, subject, this.ToString());
        using var email = new MimeMessage();

        to.ForEach(x => email.To.Add(new MailboxAddress(string.Empty, x.Trim())));

        email.From.Add(new MailboxAddress(string.Empty, from));

        email.Subject = subject;

        var builder = new BodyBuilder() { HtmlBody = body };

        email.Body = builder.ToMessageBody();

        using var smtp = new MailKit.Net.Smtp.SmtpClient();

        await smtp.ConnectAsync(_mailserverConfiguration.Hostname, _mailserverConfiguration.Port, false).ConfigureAwait(false);

        await smtp.AuthenticateAsync(_mailserverConfiguration.UserName, _mailserverConfiguration.Password).ConfigureAwait(false);

        var result = await smtp.SendAsync(email).ConfigureAwait(false);

        await smtp.DisconnectAsync(true).ConfigureAwait(false);

        return Result.Success();
    }
}
