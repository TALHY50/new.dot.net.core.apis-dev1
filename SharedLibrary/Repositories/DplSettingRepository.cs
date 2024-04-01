using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Repositories
{
    public class DplSettingRepository : GenericRepository<DplSetting>, IDplSettingRepository
    {
        public DplSettingRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public DplSetting? FindByMerchantId(int merchantId)
        {
           
            return UnitOfWork.ApplicationDbContext.DplSettings.Where(dplSetting => dplSetting.MerchantId == merchantId).FirstOrDefault();
        }
    }
}
