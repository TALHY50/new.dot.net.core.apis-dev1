using Ardalis.SharedKernel;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Common.Interfaces.Repositories;
using SharedKernel.Main.Application.Common.Models;
using SharedKernel.Main.Infrastructure.Extensions;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>, IExtendedRepositoryBase<T> where T : class, IAggregateRoot
{
    private readonly DbContext _dbContext;
    public EfRepository(DbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<List<T>> ListPaginatedAsync(int pageNumber, int pageSize,
        CancellationToken cancellationToken = default)
    { 
        var result = await _dbContext.Set<T>().AsQueryable().PaginatedListAsync(pageNumber:pageNumber, pageSize: pageSize);

        return result.Items;
    }
}