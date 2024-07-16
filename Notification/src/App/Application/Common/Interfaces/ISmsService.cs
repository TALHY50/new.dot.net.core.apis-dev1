using Credential = ACL.Application.Domain.Setups.Credential;

namespace Notification.App.Application.Common.Interfaces;

public interface ISmsService
{
    public Task<ISmsSender?> GetSmsSender(Credential credential);
}