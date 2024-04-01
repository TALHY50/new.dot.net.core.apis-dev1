namespace SharedLibrary.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> All();
    Task<T?> GetById(int id);
    Task<T> AddAsync(T entity);
    T Add(T entity);
    T Update(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    

}