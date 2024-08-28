using Notification.App.Domain.Entities.Outgoings;

namespace Notification.App.Application.Interfaces.Repositories;

public interface IEmailOutgoingRepository
{
    Task<EmailOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}