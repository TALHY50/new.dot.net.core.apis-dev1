using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using Thunes.Request.Transaction.Quoatation;
using Thunes.Response.Transfer.Quotation;

namespace IMT.App.Application.Interfaces.Services
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
