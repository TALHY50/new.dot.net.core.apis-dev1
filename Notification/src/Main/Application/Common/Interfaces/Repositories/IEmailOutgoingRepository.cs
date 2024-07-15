using ACL.Application.Domain.Notifications.Outgoings;

namespace Notification.Main.Application.Common.Interfaces.Repositories;

public interface IEmailOutgoingRepository
{
    Task<EmailOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}