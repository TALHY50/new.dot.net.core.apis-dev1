using IMT.Application.Application.Ports.Repositories;
using IMT.Application.Contracts.Requests;
using IMT.Thunes.Request.Transaction.Quotation;
using IMT.Thunes.Response.Transfer.Quotation;
using SharedKernel.Domain.IMT;

namespace IMT.Application.Application.Ports.Services
{
    public interface IImtQuotationService : IImtQuotationRepository
    {
        public bool IsValid(QuotationRequest request);
        public IMT.Thunes.Request.Transaction.Quotation.CreateQuotationRequest PrepareThunesCreateQuotationRequest(QuotationRequest request);
        public ImtQuotation PrepareImtQuotation(QuotationRequest request);
        public CreateContentQuotationResponse CreateQuotation(CreateQuotationRequest request);
        public CreateContentQuotationResponse GetQuotationById(ulong id);
        public CreateContentQuotationResponse GetQuotationByExternalId(ulong external_id);
        public CreateContentQuotationResponse CreateQuotationCombined(QuotationRequest quotationRequest);
    }
}
