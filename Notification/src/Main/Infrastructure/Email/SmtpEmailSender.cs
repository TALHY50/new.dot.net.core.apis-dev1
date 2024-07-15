using Microsoft.Extensions.Logging;

using MimeKit;

using Notification.Main.Application.Common.Interfaces;

namespace Notification.Main.Infrastructure.Email;

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

    public async Task SendEmailAsync(string to, string from, string subject, string body)
    {
        using var email = new MimeMessage();

        email.From.Add(new MailboxAddress("Sender Name", "rifat.simoom@gmail.com"));

        email.To.Add(new MailboxAddress("Fakkir", "rifat.simoom@gmail.com"));

        email.Subject = "Notification";

        var builder = new BodyBuilder() { TextBody = @"Hey, Just Hi!" };

        email.Body = builder.ToMessageBody();

        using var smtp = new MailKit.Net.Smtp.SmtpClient();

        await smtp.ConnectAsync("sandbox.smtp.mailtrap.io", 587, false).ConfigureAwait(false);

        await smtp.AuthenticateAsync("92e0ae7a791f20", "17d5b1ee026744").ConfigureAwait(false);

        await smtp.SendAsync(email).ConfigureAwait(false);

        _logger.LogWarning("Sending email to {to} from {from} with subject {subject} using {type}.", to, from, subject, this.ToString());
    }
}
