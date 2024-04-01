using CommercialCardCommission = SharedLibrary.Models.CommercialCardCommission;

namespace SharedLibrary.Interfaces.Repositories;

public interface ICommercialCardCommissionRepository : IGenericRepository<CommercialCardCommission>
{
    public CommercialCardCommission GetByProgram(uint merchant_id, string card_program, int currency_id,
        sbyte installment_number, int status);
}