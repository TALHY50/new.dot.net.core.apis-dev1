using IMT.App.Application.Ports.Repositories;
using IMT.App.Contracts.Requests;
using SharedKernel.Main.Domain.IMT;
using Thunes.Request.Transaction.Quoatation;
using Thunes.Response.Transfer.Quotation;
using Quotation = SharedKernel.Main.Domain.IMT.Quotation;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtQuotationService : IImtQuotationRepository
    {
        public bool IsValid(QuotationRequest request);
        public CreateQuotationRequest PrepareThunesCreateQuotationRequest(QuotationRequest request);
        public Quotation PrepareImtQuotation(QuotationRequest request);
        public CreateContentQuotationResponse CreateQuotation(CreateQuotationRequest request);
        public CreateContentQuotationResponse GetQuotationById(ulong id);
        public CreateContentQuotationResponse GetQuotationByExternalId(ulong external_id);
        public CreateContentQuotationResponse CreateQuotationCombined(QuotationRequest quotationRequest);
    }
}
