using Notification.App.Application.Common.Interfaces;
using Notification.App.Domain.ValueObjects;
using Notification.App.Infrastructure.Sms;

using Credential = Notification.App.Domain.Setups.Credential;

namespace Notification.App.Infrastructure.Services;

public class SmsService : ISmsService
{
    public SmsService()
    {
    }

    public Task<ISmsSender?> GetSmsSender(Credential credential)
    {
        var mailServerConfiguration = GetMailServerConfiguration(credential);
        ISmsSender? emailSender = SmsSenderFactory.FromConfiguration(mailServerConfiguration);
        return Task.FromResult(emailSender);
    }

    private SmsProviderConfiguration GetMailServerConfiguration(Credential credential)
    {
        var config = new SmsProviderConfiguration();
        config.Name = ProviderName.From(credential.Title);
        config.Hostname = credential.Host;
        config.Port = credential.Port;
        config.UserName = credential.Username;
        config.Password = credential.Password;

        return config;
    }
}