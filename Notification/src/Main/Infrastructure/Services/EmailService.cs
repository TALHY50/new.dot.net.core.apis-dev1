using Notification.Main.Application.Common.Interfaces;
using Notification.Main.Infrastructure.Email;
using Notification.RazorTemplateEngine.Services;

using Credential = ACL.Application.Domain.Setups.Credential;

namespace Notification.Main.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly ITemplateExecutionEngine _engine;

    public EmailService(ITemplateExecutionEngine engine)
    {
        _engine = engine;
    }

    public async Task<string> GenerateEmailBody(string templatePath, string jsonData)
    {
        return await _engine.RenderTemplate(templatePath, jsonData).ConfigureAwait(false);
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