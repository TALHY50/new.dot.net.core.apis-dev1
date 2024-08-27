using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.IMT.Domain.Entities;
using Thunes.Request.Transaction.Quoatation;
using Thunes.Response.Transfer.Quotation;

namespace SharedKernel.Main.IMT.Application.Interfaces.Services
{
    public interface IQuotationService : IQuotationRepository
    {
        public bool IsValid(QuotationRequest request);
        public CreateQuotationRequest PrepareThunesCreateQuotationRequest(QuotationRequest request);
        public SharedKernel.Main.IMT.Domain.Entities.Quotation PrepareImtQuotation(QuotationRequest request);
        public CreateContentQuotationResponse CreateQuotation(CreateQuotationRequest request);
        public CreateContentQuotationResponse GetQuotationById(ulong id);
        public CreateContentQuotationResponse GetQuotationByExternalId(string invoice_id);
        public CreateContentQuotationResponse CreateQuotationCombined(QuotationRequest quotationRequest);
    }
}
