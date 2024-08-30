using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IImtPayerRepository
    {
        Payer? Add(Payer payer);
        Payer? Update(Payer payer);
        List<Payer> GetAll();
        bool Delete(Payer payer);
        Payer? FindById(uint id);
    }
}
