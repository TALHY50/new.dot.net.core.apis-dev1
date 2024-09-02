using ErrorOr;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Infrastructure.Persistence;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedKernel.Main.Application.Interfaces.Services;

public interface ITransactionHandler
{
    Task<ErrorOr<T>> ExecuteWithTransactionAsync<T>(
        TransactionHandler.TransactionOperation<T> operation,
        DbContext context,
        int maxRetryCount=0, 
        CancellationToken cancellationToken = default);
}