using Microsoft.Extensions.Logging;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class PosIssuerTagRepository
{
    private readonly ILogger<object> _logger;
    private readonly ApplicationDbContext _context;
    public PosIssuerTagRepository(ILogger<object> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public List<int> GetAllUniqueIsserByPosIdListNew(string program_name, List<int> posIdList, string issuer_name)
    {

        var finalPosIdList = new List<int>();

        if (posIdList.Count > 0)
        {
            if (!string.IsNullOrEmpty(program_name) && !string.IsNullOrEmpty(issuer_name) && program_name != "UNKNOWN")
            {
                var bankIds = _context.Banks.Where(c => c.IssuerName == issuer_name).Select(v => v.Id).ToList();

                var posIds = _context.Pos.Where(c => c.Program == program_name).Select(m => m.Id).ToList();

                if (bankIds.Count > 0 && posIds.Count > 0)
                {
                    var posIssuerTagObjList = _context.PosIssuerTags
                            .Where(c => bankIds.Contains(c.Id) && posIds.Contains(Convert.ToInt32(c.PosId)))
                            .ToList();

                    if (posIssuerTagObjList.Count > 0)
                    {
                        foreach (var item in posIssuerTagObjList)
                        {
                            int posId = Convert.ToInt32(item.PosId);

                            if (posIdList.Contains(posId))
                            {
                                finalPosIdList.Add(posId);
                            }
                        }

                    }
                }


            }
        }

        if (Constants.BrandConfiguration.IsTenant())
        {
            finalPosIdList = posIdList;
        }

        return finalPosIdList;
    }
}