using SharedBusiness.Main.IMT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtMttPaymentSpeedRepository
    {
        MttPaymentSpeed? Add(MttPaymentSpeed mttPaymentSpeed);
        MttPaymentSpeed? Update(MttPaymentSpeed mttPaymentSpeed);
        bool Delete(MttPaymentSpeed mttPaymentSpeed);
        MttPaymentSpeed? View(uint id);
        IEnumerable<MttPaymentSpeed>? GetAll();
    }
}
