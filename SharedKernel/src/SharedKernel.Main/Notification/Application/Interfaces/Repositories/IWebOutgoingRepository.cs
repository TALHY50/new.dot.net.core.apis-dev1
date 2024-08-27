using SharedKernel.Main.Notification.Domain.Entities.Outgoings;

namespace SharedKernel.Main.Notification.Application.Interfaces.Repositories;

public interface IWebOutgoingRepository
{
    Task<WebOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}