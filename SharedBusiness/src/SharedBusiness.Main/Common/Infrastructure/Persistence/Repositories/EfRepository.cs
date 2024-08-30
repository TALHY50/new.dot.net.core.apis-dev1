using Ardalis.SharedKernel;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(DbContext dbContext) : base(dbContext)
    {
    }
}