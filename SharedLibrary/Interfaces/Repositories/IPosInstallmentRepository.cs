using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IPosInstallmentRepository : IGenericRepository<PosInstallment>
{
    Dictionary<int, Dictionary<int, PosInstallment>> FindPosInstallmentByPosIds(List<int> posIds);
    
    PosInstallment? GetPosInstallmentByIdNInstallment(int pos_id, int installment_number);

    (decimal cost, decimal cotPercentage, decimal cotFixed) GetCostOfTransaction(int pos_id, int installment,
        decimal amount, PosInstallment? posInstallment);

}