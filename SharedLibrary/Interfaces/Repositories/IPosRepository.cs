using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IPosRepository : IGenericRepository<Pos>
{
    public Pos? FindById(int id);
    public Pos FindActivePosById(int posId);
}