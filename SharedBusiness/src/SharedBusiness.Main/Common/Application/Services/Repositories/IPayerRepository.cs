using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface IPayerRepository : IRepository<Payer>, IExtendedRepositoryBase<Payer>
    {
    }
}
