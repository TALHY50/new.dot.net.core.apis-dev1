using Notification.App.Domain.Entities.Setups;

namespace Notification.App.Application.Interfaces.Services;

public interface ISmsService
{
    public Task<ISmsSender?> GetSmsSender(Credential credential);
}