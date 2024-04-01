namespace SharedLibrary.Interfaces.Repositories;

public interface ICurrencyRepository : IGenericRepository<Models.Currency>
{
    public Models.Currency? FindByCode(string code);
    
    public Models.Currency? FindById(int? id);
    
}