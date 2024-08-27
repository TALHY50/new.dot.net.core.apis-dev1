﻿using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Services;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Contracts.Requests;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Configurations;
using SharedKernel.Main.Infrastructure.Persistence.Repositories.Quotation;
using Thunes;
using Thunes.Exception;
using Thunes.Request.Common;
using Thunes.Request.Transaction.Quoatation;
using Thunes.Response.Common;
using Thunes.Response.Transfer.Quotation;
using QuotationRequest = SharedKernel.Main.Infrastructure.Persistence.IMT.Contracts.Requests.QuotationRequest;

namespace IMT.App.Infrastructure.Persistence.Services.Quotation
{

#pragma warning disable CS8629 // Nullable value type may be null.
    public class ImtQuotationService : QuotationRepository, IQuotationService
    {
        // public readonly ThunesClient _thunesClient = new(Env.GetString("THUNES_API_KEY"), Env.GetString("THUNES_API_SECRET"), Env.GetString("THUNES_BASE_URL"));
        public readonly ThunesClient _thunesClient = new("f1c4a4d9-2899-4f09-b9f5-c35f09df5ffd", "bed820bd-264b-4d0f-8148-9f56e0a8b55c", "https://api-mt.pre.thunes.com");
        public IImtCountryRepository _countryRepository;
        public IImtCurrencyRepository _currencyRepository;
        public IImtProviderErrorDetailsRepository _errorRepository;
        public SharedKernel.Main.Domain.IMT.Entities.Quotation Quotation = null;

        public ImtQuotationService(ApplicationDbContext dbContext,IImtCountryRepository countryRepository,IImtCurrencyRepository currencyRepository,IImtProviderErrorDetailsRepository errorRepository) : base(dbContext)
        {
            _currencyRepository = currencyRepository;
            _countryRepository = countryRepository;
            _errorRepository = errorRepository;
        }
        public CreateContentQuotationResponse CreateQuotation(CreateQuotationRequest CreateQuotationRequest)
        {
            try
            {
                return _thunesClient.QuotationAdapter().CreateQuotation(CreateQuotationRequest);
            }
            catch (ThunesException e)
            {
                ErrorStore(e.Errors);
                throw new ThunesException(e.ErrorCode, e.Errors);
            }
        }
        private void ErrorStore(List<ErrorsResponse> Errors)
        {
            foreach (var error in Errors)
            {
                ProviderErrorDetail prepareData = new ProviderErrorDetail
                {
                    ErrorCode = error.code,
                    ErrorMessage = error.message,
                    ImtProviderId = (int)Quotation.MttId,
                    ReferenceId = Quotation.Id,
                    Type = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                _errorRepository.Add(prepareData);
            }
        }
        public bool IsValid(QuotationRequest request)
        {
            List<ErrorsResponse> errors = new List<ErrorsResponse>();
            try
            {
                if (_currencyRepository.GetCurrencyIdByCode(request.source_currency_code) == null)
                {
                    errors.Add(new ErrorsResponse { code = "Request invalid", message = "source_currency_code must be valid" });
                }
                if (_countryRepository.GetCountryIdByCountryIsoCode(request.source_country_iso_code) == null)
                {
                    errors.Add(new ErrorsResponse { code = "Request invalid", message = "source_country_iso_code must be valid" });
                }
                if (_currencyRepository.GetCurrencyIdByCode(request.destination_currency_code) == null)
                {
                    errors.Add(new ErrorsResponse { code = "Request invalid", message = "destination_currency_code must be valid" });
                }

                if (errors.Count > 0)
                {
                    //return false;
                    throw new ThunesException(422, errors);
                }
                return true;
            }
            catch (ThunesException e)
            {
                throw new ThunesException(e.ErrorCode, e.Errors);
            }
        }

        public SharedKernel.Main.Domain.IMT.Entities.Quotation PrepareImtQuotation(QuotationRequest request)
        {
            return new SharedKernel.Main.Domain.IMT.Entities.Quotation
            {
                OrderId = request.invoice_id,
              //  PayerId = request.payer_id,
            //    Mode = request.mode,
           //     TransactionType = request.transaction_type,
                SourceAmount = request.source_amount,
           //     ImtSourceCurrencyId = _currencyRepository.Where(c => c.IsoCode == request.source_currency_code).ToList().OrderBy(c => c.Id)?.Last().Id,
          //      ImtProviderId = 1, // hardcoded for thunes
           //     ImtProviderServiceId = 1,// hardcoded for thunes
           //     ImtSourceCountryId = _countryRepository.Where(c => c.IsoCode == request.source_country_iso_code).ToList().OrderBy(c => c.Id)?.Last().Id,
                DestinationAmount = request.destination_amount,
            //    ImtDestinationCurrencyId = _currencyRepository.Where(c => c.IsoCode == request.destination_currency_code).ToList().OrderBy(c => c.Id)?.Last().Id,
                CreatedAt = DateTime.UtcNow,
            };
        }

        public CreateQuotationRequest PrepareThunesCreateQuotationRequest(QuotationRequest request)
        {
            return new CreateQuotationRequest
            {
                external_id = request.invoice_id,
                payer_id = request.payer_id,
                mode = request.mode,
                transaction_type = request.transaction_type,
                source = new SourceOne
                {
                    amount = (request.mode == "SOURCE_AMOUNT") ? (double?)((request.source_amount == null) ? 0 : request.source_amount) : null,
                    currency = request.source_currency_code,
                    country_iso_code = request.source_country_iso_code
                },
                destination = new DestinationOne
                {
                    amount = (double?)((request.destination_amount == null) ? 0 : request.destination_amount),
                    currency = request.destination_currency_code,
                }
            };
        }

        public CreateContentQuotationResponse GetQuotationById(ulong id)
        {
            return _thunesClient.QuotationAdapter().GetQuotationById(id);
        }
        public CreateContentQuotationResponse GetQuotationByExternalId(string invoice_id)
        {
            return _thunesClient.QuotationAdapter().GetQuotationByExternalId(invoice_id);
        }
        public CreateContentQuotationResponse CreateQuotationCombined(QuotationRequest quotationRequest)
        {
            if (IsValid(quotationRequest))
            {
                Quotation = Add(PrepareImtQuotation(quotationRequest));
                try
                {
                    return CreateQuotation(PrepareThunesCreateQuotationRequest(quotationRequest));
                }
                catch (ThunesException e)
                {
                    throw new ThunesException(e.ErrorCode, e.Errors);
                }
            }
            throw new ThunesException(422, "Not a valid request");
        }
    }
}
