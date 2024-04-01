using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Repositories
{
    public class DplRecurringSettingRepository : GenericRepository<DplRecurringSetting>, IDplRecurringSettingRepository
    {
        public DplRecurringSettingRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
