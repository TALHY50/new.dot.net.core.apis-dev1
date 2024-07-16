using ACL.Application.Domain.Notifications.Outgoings;

namespace Notification.App.Application.Common.Interfaces.Repositories;

public interface IEmailOutgoingRepository
{
    Task<EmailOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}