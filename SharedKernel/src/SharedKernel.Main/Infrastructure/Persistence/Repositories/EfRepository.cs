using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Interfaces.Repositories;
using SharedKernel.Main.Infrastructure.Extensions;

namespace SharedKernel.Main.Infrastructure.Persistence.Repositories;

public class EfRepository<T>(DbContext dbContext)
    : RepositoryBase<T>(dbContext), IRepositoryBase<T>, IExtendedRepositoryBase<T>
    where T : class
{
    private readonly DbContext _dbContext = dbContext;

    public virtual async Task<List<T>> ListPaginatedAsync(int pageNumber, int pageSize,
        CancellationToken cancellationToken = default)
    { 
        var result = await _dbContext.Set<T>().AsQueryable().PaginatedListAsync(pageNumber:pageNumber, pageSize: pageSize);

        return result.Items;
    }
    
}