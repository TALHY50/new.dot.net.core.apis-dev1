using Microsoft.Extensions.Logging;

using Notification.App.Application.Interfaces.Services;
using Notification.App.Domain.Entities.ValueObjects;

namespace Notification.App.Infrastructure.Sms;

public class SmsSenderFactory
{
    public static ISmsSender? FromConfiguration(SmsProviderConfiguration config)
    {
        var logger = new LoggerFactory();
        var driverType = config.Name;
        if (driverType.Equals(ProviderName.Ozeki))
        {
            return new OzekiSmsSender(logger.CreateLogger<OzekiSmsSender>(), config);
        }

        if (driverType == TransportDriverType.NotSet)
        {
            return new FakeSmsSender(logger.CreateLogger<FakeSmsSender>());
        }

        return null;
    }
}