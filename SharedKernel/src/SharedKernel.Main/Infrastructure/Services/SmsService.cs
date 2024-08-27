using SharedKernel.Main.Application.Common.Interfaces;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Sms;
using SharedKernel.Main.Notification.Domain.Entities.ValueObjects;
using Credential = SharedKernel.Main.Notification.Domain.Entities.Setups.Credential;

namespace SharedKernel.Main.Infrastructure.Services;

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