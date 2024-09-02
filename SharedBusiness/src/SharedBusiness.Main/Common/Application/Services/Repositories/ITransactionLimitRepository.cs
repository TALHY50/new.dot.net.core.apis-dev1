using Ardalis.SharedKernel;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface ITransactionLimitRepository : IRepository<TransactionLimit>, IExtendedRepositoryBase<TransactionLimit>
    {
        TransactionLimit? Edit(uint id, TransactionLimit transactionLimit);
        TransactionLimit? FindById(uint id);
        bool DeleteById(uint id);
        bool IsCurrencyExist(uint currencyId);
    }
}
