using Ardalis.SharedKernel;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface ITransactionLimitRepository : IRepository<TransactionLimit>, IExtendedRepositoryBase<TransactionLimit>
    {
        bool IsCurrencyExist(uint currencyId);
        bool IsTransactionTypeExist(sbyte transactionTypeId);
    }
}
