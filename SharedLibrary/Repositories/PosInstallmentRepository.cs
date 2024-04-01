using Microsoft.Extensions.Hosting;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class PosInstallmentRepository: GenericRepository<PosInstallment>, IPosInstallmentRepository
{
    public PosInstallmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        
    }

    public Dictionary<int, Dictionary<int, PosInstallment>> FindPosInstallmentByPosIds(List<int> posIds)
    {
        Dictionary<int, Dictionary<int, PosInstallment>> posCommissionByInstallment = new Dictionary<int, Dictionary<int, PosInstallment>>();
        List<PosInstallment> posInstallmentList = UnitOfWork.ApplicationDbContext.PosInstallments.Where(installment => posIds.Contains(installment.PosId)).ToList();

        foreach (PosInstallment posInstallment in posInstallmentList)
        {
            if (!posCommissionByInstallment.ContainsKey(posInstallment.PosId))
                posCommissionByInstallment[posInstallment.PosId] = new Dictionary<int, PosInstallment>();

            posCommissionByInstallment[posInstallment.PosId][posInstallment.InstallmentsNumber] = posInstallment;
        }

        return posCommissionByInstallment;
    }
    
    public PosInstallment? GetPosInstallmentByIdNInstallment(int pos_id, int installment_number){
        return UnitOfWork.ApplicationDbContext.PosInstallments.FirstOrDefault(s => s.PosId == pos_id && 
            s.InstallmentsNumber == installment_number);        
   }

    public (decimal cost, decimal cotPercentage, decimal cotFixed) GetCostOfTransaction(int pos_id, int installment, decimal amount, PosInstallment? posInstallment)
    {
        decimal cost = 0, cotPercentage = 0, cotFixed = 0;
        if (posInstallment == null){
            posInstallment = UnitOfWork.ApplicationDbContext.PosInstallments
                .FirstOrDefault(s => s.PosId == pos_id && 
                                     s.InstallmentsNumber == installment);
        }
        
        return ( cost, cotPercentage, cotFixed) = PosInstallmentRepository.CalculateCotByObj(posInstallment, amount);
    }

    public static (decimal cost, decimal cotPercentage, decimal cotFixed) CalculateCotByObj(PosInstallment? posInstallment, decimal amount)
    {
        decimal cost = 0, cotPercentage = 0, cotFixed = 0; 
        if (posInstallment != null)
        {
            cotPercentage = Convert.ToDecimal(posInstallment.CotPercentage);
            cotFixed = Convert.ToDecimal(posInstallment.CotFixed);
            cost = ((amount * Convert.ToDecimal(posInstallment.CotPercentage)) / 100) + Convert.ToDecimal(posInstallment.CotFixed);
        }
        return (cost, cotPercentage, cotFixed);
    }
}