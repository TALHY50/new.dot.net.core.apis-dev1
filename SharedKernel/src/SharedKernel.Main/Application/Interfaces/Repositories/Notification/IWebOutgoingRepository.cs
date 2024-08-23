using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;

namespace SharedKernel.Main.Application.Interfaces.Repositories.Notification;

public interface IWebOutgoingRepository
{
    Task<WebOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}