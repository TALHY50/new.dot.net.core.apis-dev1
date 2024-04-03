using ACL.Interfaces;
using ACL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected IUnitOfWork UnitOfWork;
        internal DbSet<T> _dbSet;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _dbSet = unitOfWork.ApplicationDbContext.Set<T>();

        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);

            return entity;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }


    }
}
