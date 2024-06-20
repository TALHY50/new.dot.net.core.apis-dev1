using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using SharedLibrary.Interfaces;
using System.Data;
using System.Dynamic;
using System.Linq.Expressions;

namespace SharedLibrary.Services
{
 
    public class GenericRepository<T, TDbContext, TUnitOfWork>(TUnitOfWork unitOfWork, TDbContext dbContext)
        : IGenericRepository<T>
        where T : class
        where TDbContext : DbContext
        where TUnitOfWork : class
    {
        protected TUnitOfWork _unitOfWork = unitOfWork;
        protected DbSet<T> _dbSet = dbContext.Set<T>();
        protected TDbContext _dbContext = dbContext;
#pragma warning disable CS8603 // Possible null reference argument.
#pragma warning disable CA2200 // Possible null reference argument.
#pragma warning disable CS0168 // Possible null reference argument.
        public virtual async Task<T> FirstOrDefault()
        {
            return await this._dbSet.FirstOrDefaultAsync();
        }
        public async Task<T> LastOrDefault()
        {
            var allEntities = await _dbSet.ToListAsync();
            try
            {
                return allEntities.LastOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public virtual async Task<IEnumerable<T>?> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {

                return null;
            }
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

        public virtual Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
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

        public virtual Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(true);
        }
        public async Task<IEnumerable<T>> ExecuteSqlQuery(string sqlQuery, params object[] parameters)
        {
            return await _dbSet.FromSqlRaw<T>(sqlQuery, parameters).ToListAsync();
        }

        public async Task<string> ExecuteSqlQueryAsJson(string sqlQuery, params object[] parameters)
        {
            try
            {
                var result = await _dbSet.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                // Serialize the result to JSON
                var jsonResult = JsonConvert.SerializeObject(result);

                return jsonResult;
            }
            catch (Exception ex)
            {
                // Handle exceptions if needed
                // Here, you can log the exception or handle it according to your requirements
                return null;
            }
        }
        public async Task<List<dynamic>> ExecuteObjectSqlQuery(string sqlQuery)
        {
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sqlQuery;
                command.CommandType = CommandType.Text;

                await _dbContext.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var entities = new List<dynamic>();

                    while (await result.ReadAsync())
                    {
                        dynamic entity = new ExpandoObject();
                        var dict = (IDictionary<string, object>)entity;

                        for (var i = 0; i < result.FieldCount; i++)
                        {
                            var fieldName = result.GetName(i);
                            var value = result.GetValue(i);
                            dict.Add(fieldName, value);
                        }

                        entities.Add(entity);
                    }

                    return entities;
                }
            }
        }

        public async Task<string> ExecuteConcatenatedStringSqlQuery(string sqlQuery)
        {
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sqlQuery;
                command.CommandType = CommandType.Text;

                await _dbContext.Database.OpenConnectionAsync();

                // Execute the command and retrieve the concatenated string result
                var concatenatedString = await command.ExecuteScalarAsync();

                // Convert the result to string if it's not null
                return concatenatedString?.ToString();
            }
        }

        public async Task<IEnumerable<T>> ExecuteSqlQuery(string sqlQuery)
        {
            try
            {
                return await _dbSet.FromSqlRaw<T>(sqlQuery).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<string> ExecuteSqlQueryAsJson(string sqlQuery)
        {
            try
            {
                var result = await _dbSet.FromSqlRaw(sqlQuery).ToListAsync();

                // Serialize the result to JSON
                var jsonResult = JsonConvert.SerializeObject(result);

                return jsonResult;
            }
            catch (Exception ex)
            {
                // Handle exceptions if needed
                // Here, you can log the exception or handle it according to your requirements
                return null;
            }
        }
        public async Task<IEnumerable<T>> AddAll(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }
        public async Task<int> DeleteAll(Expression<Func<T, bool>> predicate)
        {
            var entitiesToDelete = await _dbSet.Where(predicate).ToListAsync();
            _dbSet.RemoveRange(entitiesToDelete);
             await _dbSet.SingleAsync();
            return entitiesToDelete.Count;
        }
        public async Task<IEnumerable<T>> RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _dbSet.SingleAsync();
            return entities;
        }


        public async Task<IEnumerable<T>> AddRange(params T[] entities)
        {
            await _dbSet.AddRangeAsync(entities);
             await _dbSet.SingleAsync();
            return entities;
        }

        public virtual async Task ReloadAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbContext.Entry(entity).ReloadAsync();
        }

        public virtual async Task<T[]> ReloadAndGetEntitiesAsync(T[] entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            var reloadedEntities = new List<T>();
            foreach (var entity in entities)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                await _dbContext.Entry(entity).ReloadAsync();
                reloadedEntities.Add(entity);
            }

            return reloadedEntities.ToArray();
        }


        public void Detach(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var entry = _dbContext.Entry(entity);
            if (entry != null)
            {
                entry.State = EntityState.Detached;
            }
        }


        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual async Task<List<T>> GetAllWhere(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task ReloadEntitiesAsync(IEnumerable<T> entities)
        {
            await Task.WhenAll(entities.Select(entity => ReloadAsync(entity)));
        }

        public async Task<List<Dictionary<string, object>>?> ExecuteAnySqlQuery(string sqlQuery)
        {
            try
            {
                using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = sqlQuery;
                    command.CommandType = CommandType.Text;

                    await _dbContext.Database.OpenConnectionAsync();

                    using (var result = await command.ExecuteReaderAsync())
                    {
                        var rows = new List<Dictionary<string, object>>();

                        while (await result.ReadAsync())
                        {
                            var row = new Dictionary<string, object>();

                            // Read each field and add it to the row dictionary
                            for (var i = 0; i < result.FieldCount; i++)
                            {
                                var fieldName = result.GetName(i);
                                var value = result.GetValue(i);
                                row.Add(fieldName, value);
                            }

                            rows.Add(row);
                        }

                        return rows;
                    }
                }
            }
            catch (Exception)
            {
                // Handle exceptions if needed
                return null;
            }
        }


        public async Task<List<Dictionary<string, object>>?> ExecuteStoredProcedure(string storedProcedureName, params object[] parameters)
        {
            try
            {
                using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = storedProcedureName;
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (var parameter in parameters)
                    {
                        var param = command.CreateParameter();
                        // Set parameter properties...
                        command.Parameters.Add(param);
                    }

                    await _dbContext.Database.OpenConnectionAsync();

                    using (var result = await command.ExecuteReaderAsync())
                    {
                        var rows = new List<Dictionary<string, object>>();

                        while (await result.ReadAsync())
                        {
                            var row = new Dictionary<string, object>();

                            for (var i = 0; i < result.FieldCount; i++)
                            {
                                var fieldName = result.GetName(i);
                                var value = result.GetValue(i);
                                row.Add(fieldName, value);
                            }

                            rows.Add(row);
                        }

                        return rows;
                    }
                }
            }
            catch (Exception)
            {
                // Handle exceptions if needed
                return null;
            }
        }
    }
}