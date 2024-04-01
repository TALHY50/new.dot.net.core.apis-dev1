using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface ICcBlockListsRepository : IGenericRepository<CCBlockList>
{
    public bool IsCardBlocked(string card_no, int merchant_id);
}