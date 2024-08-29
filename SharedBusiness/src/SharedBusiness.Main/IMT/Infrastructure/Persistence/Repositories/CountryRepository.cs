using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;
using System.Linq.Expressions;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories
{
    public class CountryRepository(ApplicationDbContext dbContext) : IAdminCountryRepository
    {
        public Country Add(Country entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> AddAll(IEnumerable<Country> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Country> AddAsync(Country entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> AddRange(params Country[] entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country>? All()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Country entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAll(Expression<Func<Country, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Country entity)
        {
            throw new NotImplementedException();
        }

        public void Detach(Country entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dictionary<string, object>>?> ExecuteAnySqlQuery(string sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<string> ExecuteConcatenatedStringSqlQuery(string sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<List<dynamic>> ExecuteObjectSqlQuery(string sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> ExecuteSqlQuery(string sqlQuery, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> ExecuteSqlQuery(string sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<string> ExecuteSqlQueryAsJson(string sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<string> ExecuteSqlQueryAsJson(string sqlQuery, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dictionary<string, object>>?> ExecuteStoredProcedure(string storedProcedureName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<Country> FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public Task<List<Country>> GetAllWhere(Expression<Func<Country, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Country? GetById(ulong id)
        {
            throw new NotImplementedException();
        }

        public Country? GetByIntId(int id)
        {
            throw new NotImplementedException();
        }

        public Country? GetByUintId(uint id)
        {
            throw new NotImplementedException();
        }

        public Country? GetByUlongId(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<Country> LastOrDefault()
        {
            throw new NotImplementedException();
        }

        public Task<Country[]> ReloadAndGetEntitiesAsync(Country[] entities)
        {
            throw new NotImplementedException();
        }

        public Task ReloadAsync(Country entity)
        {
            throw new NotImplementedException();
        }

        public Task ReloadEntitiesAsync(IEnumerable<Country> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> RemoveRange(IEnumerable<Country> entities)
        {
            throw new NotImplementedException();
        }

        public Country Update(Country entity)
        {
            throw new NotImplementedException();
        }

        public Task<Country> UpdateAsync(Country entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Country?> Where(Expression<Func<Country, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
