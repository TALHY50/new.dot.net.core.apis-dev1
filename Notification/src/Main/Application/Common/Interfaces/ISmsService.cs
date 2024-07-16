using Credential = ACL.Application.Domain.Setups.Credential;

namespace Notification.Main.Application.Common.Interfaces;

public interface ISmsService
{
    public Task<ISmsSender?> GetSmsSender(Credential credential);
}