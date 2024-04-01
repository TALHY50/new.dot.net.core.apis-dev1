using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface ISettlementRepository : IGenericRepository<Settlement>
{
    public Settlement FirstById(int settlementId);
    public int? ChooseSettlementIdByInstallment(int installmentNumber, int? settlementId, int? SinglePaymentSettlementId);
    public Settlement GetSettlemnetById(int? settlementId);
}