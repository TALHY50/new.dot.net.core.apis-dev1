using Credential = SharedKernel.Main.Notification.Domain.Entities.Setups.Credential;

namespace SharedKernel.Main.Application.Common.Interfaces.Services;

public interface ISmsService
{
    public Task<ISmsSender?> GetSmsSender(Credential credential);
}