using Notification.App.Infrastructure.Sms;

using SharedKernel.Main.Application.Common.Common.Interfaces;
using SharedKernel.Main.Domain.Notification.ValueObjects;

using Credential = SharedKernel.Main.Domain.Notification.Setups.Credential;

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