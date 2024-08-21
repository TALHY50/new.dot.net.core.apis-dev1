using SharedKernel.Main.Domain.Notifications.Outgoings;

namespace SharedKernel.Main.Application.Common.Interfaces.Repositories;

public interface ISmsOutgoingRepository
{
    Task<SmsOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}