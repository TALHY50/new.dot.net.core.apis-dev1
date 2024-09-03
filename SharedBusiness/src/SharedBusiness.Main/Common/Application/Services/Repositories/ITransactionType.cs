using Ardalis.SharedKernel;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Interfaces.Services;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface ITransactionType : IRepository<TransactionType>, IExtendedRepositoryBase<TransactionType>
    {
    }
}
