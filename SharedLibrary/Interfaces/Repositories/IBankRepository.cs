using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IBankRepository : IGenericRepository<Bank>
{
    public Bank? FindById(int bank_id);
    public Bank? FindByCode(string code);

}