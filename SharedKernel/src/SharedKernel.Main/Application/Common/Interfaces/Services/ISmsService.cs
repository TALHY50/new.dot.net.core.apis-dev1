using Credential = SharedKernel.Main.Domain.Notification.Setups.Credential;

namespace SharedKernel.Main.Application.Common.Interfaces.Services;

public interface ISmsService
{
    public Task<ISmsSender?> GetSmsSender(Credential credential);
}