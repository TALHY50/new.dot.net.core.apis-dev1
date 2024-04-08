using ACL.Interfaces;
using ACL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ACL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected IUnitOfWork _unitOfWork;
        internal DbSet<T> _dbSet;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = unitOfWork.ApplicationDbContext.Set<T>();

        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetById(ulong id)
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
        public async Task<IEnumerable<T>> ExecuteSqlQuery(string sqlQuery, params object[] parameters)
        {
            return await _dbSet.FromSqlRaw<T>(sqlQuery, parameters).ToListAsync();
        }
        public async Task<IEnumerable<T>> ExecuteSqlQuery(string sqlQuery)
        {
            return await _dbSet.FromSqlRaw<T>(sqlQuery).ToListAsync();
        }
        public async Task<IEnumerable<T>> AddAll(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return entities;
        }


        public async Task<IEnumerable<T>> AddRange(params T[] entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public virtual async Task ReloadAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _unitOfWork.ApplicationDbContext.Entry(entity).ReloadAsync();
        }

        public void Detach<T>(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var entry = _unitOfWork.ApplicationDbContext.Entry(entity);
            if (entry != null)
            {
                entry.State = EntityState.Detached;
            }
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.ApplicationDbContext.Set<T>().Where(predicate);
        }

    }
}
