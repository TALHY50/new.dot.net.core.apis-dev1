using Notification.App.Application.Interfaces.Services;
using Notification.App.Domain.Entities.Setups;

namespace Notification.App.Infrastructure.Email;

public class EmailService : IEmailService
{
    public EmailService()
    {
    }

    public Task<IEmailSender?> GetEmailSender(Credential credential)
    {
        var mailServerConfiguration = GetMailServerConfiguration(credential);
        IEmailSender? emailSender = EmailSenderFactory.FromConfiguration(mailServerConfiguration);
        return Task.FromResult(emailSender);
    }

    private MailserverConfiguration GetMailServerConfiguration(Credential credential)
    {
        var mailServerConfiguration = new MailserverConfiguration();
        mailServerConfiguration.Hostname = credential.Host;
        mailServerConfiguration.Port = credential.Port;
        mailServerConfiguration.TransportDriverType = credential.TransportDriver;
        mailServerConfiguration.UserName = credential.Username;
        mailServerConfiguration.Password = credential.Password;

        return mailServerConfiguration;
    }
}