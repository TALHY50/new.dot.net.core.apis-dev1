using Notification.App.Domain.Notifications.Outgoings;

namespace Notification.App.Application.Common.Interfaces.Repositories;

public interface ISmsOutgoingRepository
{
    Task<SmsOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}