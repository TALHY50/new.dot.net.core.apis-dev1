using Notification.App.Domain.Notifications.Outgoings;

namespace Notification.App.Application.Common.Interfaces.Repositories;

public interface IWebOutgoingRepository
{
    Task<WebOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}