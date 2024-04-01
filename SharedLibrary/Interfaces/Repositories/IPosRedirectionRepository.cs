using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IPosRedirectionRepository: IGenericRepository<PosRedirection>
{
    public List<PosRedirection> GetByPosIds(List<int> posIds, uint merchantId);

    public int FindRedirectedPosId(object from_pos, int merchant_id);

    public IQueryable<PosRedirection> CommonFilters(object from_pos, int merchant_id);




}