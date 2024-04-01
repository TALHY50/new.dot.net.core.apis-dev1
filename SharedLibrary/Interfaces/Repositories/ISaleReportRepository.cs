using SharedLibrary.Models;
using SharedLibrary.Repositories;

namespace SharedLibrary.Interfaces.Repositories;

public interface ISaleReportRepository : IGenericRepository<SaleReport>
{
    public SaleReport? FindBySaleId(int saleId);


}