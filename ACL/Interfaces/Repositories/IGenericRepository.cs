namespace ACL.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T?> GetById(int id);
        Task<T> AddAsync(T entity);
        T Add(T entity);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<IEnumerable<T>> ExecuteSqlQuery(string sqlQuery, params object[] parameters);
        Task<IEnumerable<T>> ExecuteSqlQuery(string sqlQuery);
        Task<IEnumerable<T>> AddAll(IEnumerable<T> entities);
        Task<IEnumerable<T>> AddRange(params T[] entities);
    }
}
