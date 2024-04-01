using System.Text.Json;
using Microsoft.Extensions.Logging;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class CommercialCardCommissionRepository : GenericRepository<CommercialCardCommission>, ICommercialCardCommissionRepository
{
    private readonly ILogger<object> _logger;
    private readonly ApplicationDbContext _context;

    const int STATUS_ACTIVE = 1;
    const int STATUS_INACTIVE = 0;

    public CommercialCardCommissionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        
    }

    //in PHP it was implemented peculiarly expensive way
    public CommercialCardCommission GetByProgram(uint merchant_id, string card_program, int currency_id, sbyte installment_number, int status = STATUS_ACTIVE)
    {
        var commercial_pos_commission_key = card_program + currency_id + status + merchant_id + "CommercialPosCommissionCollection";
        CommercialCardCommission commercialCardCommission = new();
        //TODO: save the key<commercial_pos_commission_key> to do lookup for next time
        // if (GetResource(commercial_pos_commission_key) is CommercialCardCommissionCollection res)
        // {
        //     return res;
        // }
        // else
        {
            var q = UnitOfWork.ApplicationDbContext.CommercialCardCommissions
            .Where(ccc => ccc.Program == card_program 
            && ccc.Status == status 
            && ccc.CurrencyId == currency_id 
            && ccc.MerchantId == merchant_id
            && ccc.InstallmentNumber== installment_number).FirstOrDefault();
            commercialCardCommission = q??new();
            //SetResource(commercial_pos_commission_key, commercialCardCommissionCollection);

            UnitOfWork.Logger.LogInformation(JsonSerializer.Serialize(
                new Dictionary<string,object>{
                    {"action" , "COMMERCIAL_CARD_COMMISSION"},
                    {"commercial_card_commission_collection", commercialCardCommission}
                }
            ));
            
        }

        return commercialCardCommission;
    }
}
