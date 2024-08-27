using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Common.Interfaces;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Notification.Domain.Entities.ValueObjects;

namespace SharedKernel.Main.Infrastructure.Sms;

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