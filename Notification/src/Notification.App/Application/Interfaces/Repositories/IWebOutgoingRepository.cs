using Notification.App.Domain.Entities.Outgoings;

namespace Notification.App.Application.Interfaces.Repositories;

public interface IWebOutgoingRepository
{
    Task<WebOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}