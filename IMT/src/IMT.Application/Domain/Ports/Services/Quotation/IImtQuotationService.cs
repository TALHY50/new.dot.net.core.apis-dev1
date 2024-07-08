using IMT.Application.Contracts.Requests.Quotation;
using IMT.Application.Domain.Ports.Repositories.Quotation;
using IMT.Application.Infrastructure.Persistence.Repositories;
using IMT.Thunes.Request.Transaction.Quotation;
using SharedLibrary.Interfaces;
using SharedLibrary.Models.IMT;
using SharedLibrary.Persistence.Configurations;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Domain.Ports.Services.Quotation
{
    public interface IImtQuotationService : IImtQuotationRepository
    {
        public bool IsValid(QuotationRequest request);
        public IMT.Thunes.Request.Transaction.Quotation.CreateQuotationRequest PrepareThunesCreateQuotationRequest(QuotationRequest request);
        public ImtQuotation PrepareImtQuotation(QuotationRequest request);
        public object CreateQuotation(CreateQuotationRequest request);
        public object GetQuotationById(ulong id);
        public object GetQuotationByExternalId(ulong external_id);
    }
}
