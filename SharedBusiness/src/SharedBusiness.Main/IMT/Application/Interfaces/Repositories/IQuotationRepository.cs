using Ardalis.SharedKernel;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Interfaces.Services;

namespace SharedBusiness.Main.IMT.Application.Interfaces.Repositories
{
    public interface IQuotationRepository : IRepository<Quotation>, IExtendedRepositoryBase<Quotation>
    {
        public Quotation? GetImtQuotationByInvoiceId(string invoiceId);
    }
}
