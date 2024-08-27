using SharedKernel.Main.Notification.Domain.Entities.Outgoings;

namespace SharedKernel.Main.Notification.Application.Interfaces.Repositories;

public interface ISmsOutgoingRepository
{
    Task<SmsOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}