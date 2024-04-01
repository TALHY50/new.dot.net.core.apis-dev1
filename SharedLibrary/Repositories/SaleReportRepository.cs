using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class SaleReportRepository : GenericRepository<SaleReport>, ISaleReportRepository
{
    public SaleReportRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        
    }
    
    public  SaleReport? FindBySaleId(int saleId)
    {
        return UnitOfWork.ApplicationDbContext.SaleReports.FirstOrDefault(x => x.SaleId == saleId);
    }
}