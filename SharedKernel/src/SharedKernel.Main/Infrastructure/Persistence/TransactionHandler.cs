using System.Data;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace SharedKernel.Main.Infrastructure.Persistence;

public class TransactionHandler(ILogger<TransactionHandler> logger):ITransactionHandler
{
    
    public delegate Task<ErrorOr<T>> TransactionOperation<T>(CancellationToken cancellationToken);
    public async Task<ErrorOr<T>> ExecuteWithTransactionAsync<T>(
        TransactionOperation<T> operation, 
        DbContext context,
        int maxRetryCount, 
        CancellationToken cancellationToken)
    {
        int retryCount = 0;
        while (retryCount < maxRetryCount)
        {
            using (var transaction = await context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken))
            {
                try
                {
                    var result = await operation(cancellationToken); // Execute the passed-in block
                    if (result.IsError)
                    {
                        await transaction.RollbackAsync(cancellationToken);
                        logger.LogWarning("Attempt {RetryCount} failed: Operation returned an error", retryCount + 1);
                    }
                    else
                    {
                        await transaction.CommitAsync(cancellationToken);
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    logger.LogError(ex, "Attempt {RetryCount} failed: An error occurred during operation.", retryCount + 1);
                }
            }

            retryCount++;
            if (retryCount < maxRetryCount)
            {
                logger.LogInformation("Retrying... Attempt {RetryCount}", retryCount + 1);
                await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken); // Optional delay
            }
        }

        return Error.Unexpected(ApplicationStatusCodes.API_ERROR_UNEXPECTED_ERROR, "Failed to complete operation after multiple attempts.");
    }
}
