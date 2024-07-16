using ACL.Application.Domain.Notifications.Outgoings;

namespace Notification.Main.Application.Common.Interfaces.Repositories;

public interface ISmsOutgoingRepository
{
    Task<SmsOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}