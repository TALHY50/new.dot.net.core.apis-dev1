using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;

namespace SharedKernel.Main.Application.Common.Interfaces.Notification;

public interface IWebOutgoingRepository
{
    Task<WebOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}