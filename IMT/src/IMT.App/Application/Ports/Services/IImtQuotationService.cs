using App.Application.Ports.Repositories;
using App.Contracts.Requests;
using SharedKernel.Main.Domain.IMT;
using Thunes.Request.Transaction.Quoatation;
using Thunes.Response.Transfer.Quotation;

namespace App.Application.Ports.Services
{
    public interface IImtQuotationService : IImtQuotationRepository
    {
        public bool IsValid(QuotationRequest request);
        public CreateQuotationRequest PrepareThunesCreateQuotationRequest(QuotationRequest request);
        public ImtQuotation PrepareImtQuotation(QuotationRequest request);
        public CreateContentQuotationResponse CreateQuotation(CreateQuotationRequest request);
        public CreateContentQuotationResponse GetQuotationById(ulong id);
        public CreateContentQuotationResponse GetQuotationByExternalId(ulong external_id);
        public CreateContentQuotationResponse CreateQuotationCombined(QuotationRequest quotationRequest);
    }
}
