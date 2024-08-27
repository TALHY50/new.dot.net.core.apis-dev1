using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Contracts.Requests;
using Thunes.Request.Transaction.Quoatation;
using Thunes.Response.Transfer.Quotation;
using Quotation = SharedKernel.Main.Domain.IMT.Entities.Quotation;

namespace SharedKernel.Main.Application.Interfaces.Repositories.IMT.Services
{
    public interface IQuotationService : IQuotationRepository
    {
        public bool IsValid(QuotationRequest request);
        public CreateQuotationRequest PrepareThunesCreateQuotationRequest(QuotationRequest request);
        public Quotation PrepareImtQuotation(QuotationRequest request);
        public CreateContentQuotationResponse CreateQuotation(CreateQuotationRequest request);
        public CreateContentQuotationResponse GetQuotationById(ulong id);
        public CreateContentQuotationResponse GetQuotationByExternalId(string invoice_id);
        public CreateContentQuotationResponse CreateQuotationCombined(QuotationRequest quotationRequest);
    }
}
