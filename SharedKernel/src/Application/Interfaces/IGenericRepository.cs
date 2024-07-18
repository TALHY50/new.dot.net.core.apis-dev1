using System.Linq.Expressions;

namespace SharedKernel.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T>? All();
        T? GetById(ulong id);
        Task<T> AddAsync(T entity);
        T Add(T entity);
        Task<T> FirstOrDefault();
        Task<T> LastOrDefault();
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> Delete(T entity);
        Task<IEnumerable<T>> ExecuteSqlQuery(string sqlQuery, params object[] parameters);
        Task<IEnumerable<T>> ExecuteSqlQuery(string sqlQuery);
        Task<IEnumerable<T>> AddAll(IEnumerable<T> entities);
        Task<IEnumerable<T>> RemoveRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> AddRange(params T[] entities);
        Task ReloadAsync(T entity);
        Task<T[]> ReloadAndGetEntitiesAsync(T[] entities);
        void Detach(T entity);
        IQueryable<T?> Where(Expression<Func<T, bool>> predicate);
        Task ReloadEntitiesAsync(IEnumerable<T> entities);
        Task<List<T>> GetAllWhere(Expression<Func<T, bool>> predicate);
        Task<List<dynamic>> ExecuteObjectSqlQuery(string sqlQuery);
        Task<string> ExecuteConcatenatedStringSqlQuery(string sqlQuery);
        Task<string> ExecuteSqlQueryAsJson(string sqlQuery);
        Task<string> ExecuteSqlQueryAsJson(string sqlQuery, params object[] parameters);
        Task<List<Dictionary<string, object>>?> ExecuteAnySqlQuery(string sqlQuery);
        Task<List<Dictionary<string, object>>?> ExecuteStoredProcedure(string storedProcedureName, params object[] parameters);
        Task<int> DeleteAll(Expression<Func<T, bool>> predicate);
    }
}