using SharedBusiness.Main.Common.Domain.Entities;

namespace SharedBusiness.Main.Common.Application.Services.Repositories
{
    public interface IPayerRepository
    {
        Payer? Add(Payer payer);
        Payer? Update(Payer payer);
        List<Payer> GetAll();
        bool Delete(Payer payer);
        Payer? FindById(uint id);
    }
}
