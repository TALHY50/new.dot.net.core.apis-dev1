using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class PosRedirectionRepository : GenericRepository<PosRedirection>, IPosRedirectionRepository
{
    public const bool IS_ENABLE_POS_REDIRECTION = true;
    private readonly ApplicationDbContext _context;

    private readonly IUnitOfWork _unitOfWork;
    public PosRedirectionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<PosRedirection> GetByPosIds(List<int> posIds, uint merchantId)
    {
                return CommonFilters(posIds.ToArray(), (int)merchantId).ToList();
    }
    

    public int FindRedirectedPosId(object from_pos, int merchant_id)
    {
        int to_pos = 0;
        var result = CommonFilters(from_pos, merchant_id)
            .FirstOrDefault();

        if (result != null)
        {
            to_pos = result.ToPosId;
        }

        return to_pos;
    }

    public IQueryable<PosRedirection> CommonFilters(object from_pos, int merchant_id)
    {
        DateTime now = DateTime.Now;
        var query = _unitOfWork.ApplicationDbContext.PosRedirections.AsQueryable();

        if (from_pos is int[] posArray)
        {
            query = query.Where(pos => posArray.Contains(pos.FromPosId));
        }
        else
        {
            query = query.Where(pos => pos.FromPosId == (int)from_pos);
        }

        query = query.Where(pos =>
            (pos.MerchantIds != null &&
            pos.MerchantIds.Contains("," + merchant_id + ",")) ||
            pos.IsAllMerchant == 1
        )
        .Where(pos =>
            pos.FromDate <= now &&
            pos.ToDate >= now &&
            pos.Status == 1);

        return query;
    }

    
}