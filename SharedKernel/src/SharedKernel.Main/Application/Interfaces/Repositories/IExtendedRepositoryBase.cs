using Ardalis.SharedKernel;
using Ardalis.Specification;

namespace SharedKernel.Main.Application.Interfaces.Repositories;

public interface IExtendedRepositoryBase<T> : IRepositoryBase<T> where T : class
{
    public Task<List<T>> ListPaginatedAsync(int pageNumber, int pageSize,
        CancellationToken cancellationToken = default);
}