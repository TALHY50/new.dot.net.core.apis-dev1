using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Interfaces.Repositories;
using SharedKernel.Main.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
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
}
