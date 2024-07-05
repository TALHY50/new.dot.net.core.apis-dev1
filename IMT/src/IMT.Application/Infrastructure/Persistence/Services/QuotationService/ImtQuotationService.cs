using DotNetEnv;
using IMT.Application.Contracts.Requests.Quotation;
using IMT.Application.Domain.Ports.Repositories.ImtCurrency;
using IMT.Application.Domain.Ports.Repositories.Quotation;
using IMT.Application.Domain.Ports.Services.Quotation;
using IMT.Application.Infrastructure.Persistence.Repositories.Quotation;
using IMT.Thunes;
using IMT.Thunes.Request.Transaction.Quotation;
using IMT.Thunes.Response.Common;
using IMT.Thunes.Request.Common;
using SharedLibrary.Interfaces;
using SharedLibrary.Models.IMT;
using SharedLibrary.Persistence.Configurations;
using SharedLibrary.Repositories.Admin.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMT.Thunes.Exception;
using IMT.Application.Infrastructure.Utility;
using IMT.PayAll.Request.Common;

namespace IMT.Application.Infrastructure.Persistence.Services.QuotationService
{

#pragma warning disable CS8629 // Nullable value type may be null.
    public class ImtQuotationService : ImtQuotationRepository, IImtQuotationService
    {
        // public readonly ThunesClient _thunesClient = new(Env.GetString("THUNES_API_KEY"), Env.GetString("THUNES_API_SECRET"), Env.GetString("THUNES_BASE_URL"));
        public readonly ThunesClient _thunesClient = new("f1c4a4d9-2899-4f09-b9f5-c35f09df5ffd", "bed820bd-264b-4d0f-8148-9f56e0a8b55c", "https://api-mt.pre.thunes.com");
        public IImtCountryRepository _countryRepository;
        public IImtCurrencyRepository _currencyRepository;

        public ImtQuotationService(ApplicationDbContext dbContext) : base(dbContext)
        {
            DependencyContainer.Initialize();
            _currencyRepository = DependencyContainer.GetService<IImtCurrencyRepository>();
            _countryRepository = DependencyContainer.GetService<IImtCountryRepository>();
        }
        public object CreateQuotation(CreateQuotationRequest CreateQuotationRequest)
        {
            return _thunesClient.QuotationAdapter().CreateQuotation(CreateQuotationRequest);
        }

        public bool IsValid(QuotationRequest request)
        {
            List<ErrorsResponse> errors = new List<ErrorsResponse>();
            if (_currencyRepository.GetCurrencyCodeById((int)request.ImtSourceCurrencyId) == null)
            {
                errors.Add(new ErrorsResponse { code = "Request invalid", message = "ImtSourceCurrencyId must be valid" });
            }
            if (_countryRepository.GetCountryIsoCodeByCountryId((int)request.ImtSourceCountryId) == null)
            {
                errors.Add(new ErrorsResponse { code = "Request invalid", message = "ImtSourceCountryId must be valid" });
            }
            if (_currencyRepository.GetCurrencyCodeById((int)request.ImtDestinationCurrencyId) == null)
            {
                errors.Add(new ErrorsResponse { code = "Request invalid", message = "ImtDestinationCurrencyId must be valid" });
            }

            if (errors.Count > 0)
            {
                //return false;
                throw new ThunesException(422, errors);
            }
            return true;
        }

        public ImtQuotation PrepareImtQuotation(QuotationRequest request)
        {
            return new ImtQuotation
            {
                OrderId = request.OrderId,
                PayerId = request.PayerId,
                Mode = request.Mode,
                TransactionType = request.TransactionType,
                SourceAmount = request.SourceAmount,
                ImtSourceCurrencyId = request.ImtSourceCurrencyId,
                ImtProviderId = request.ImtProviderId,
                ImtProviderServiceId = request.ImtProviderServiceId,
                ImtSourceCountryId = request.ImtSourceCountryId,
                DestinationAmount = request.DestinationAmount,
                ImtDestinationCurrencyId = request.ImtDestinationCurrencyId,
                CreatedAt = DateTime.UtcNow,
            };
        }

        public CreateQuotationRequest PrepareThunesCreateQuotationRequest(QuotationRequest request)
        {
            return new CreateQuotationRequest
            {
                external_id = request.OrderId,
                payer_id = request.PayerId,
                mode = request.Mode,
                transaction_type = request.TransactionType,
                source = new SourceOne
                {
                    amount = (request.Mode=="SOURCE_AMOUNT")?(double?)((request.SourceAmount == null) ? 0 : request.SourceAmount):null,
                    currency = _currencyRepository.GetCurrencyCodeById((int)request.ImtSourceCurrencyId),
                    country_iso_code = _countryRepository.GetCountryIsoCodeByCountryId((int)request.ImtSourceCountryId)
                },
                destination = new DestinationOne
                {
                    amount = (double?)((request.DestinationAmount == null) ? 0 : request.DestinationAmount),
                    currency = _currencyRepository.GetCurrencyCodeById((int)request.ImtDestinationCurrencyId),
                }
            };
        }
    }
}
