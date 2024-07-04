using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;
using IMT.Contracts.Request.Quotation;
using IMT.Thunes;
using IMT.Thunes.Exception;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Request.Transaction.Quotation;
using IMT.Thunes.Response.Common;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models.IMT;
using SharedLibrary.Persistence.Configurations;

namespace IMT.Web.Controllers.Quotation
{

    [ApiController]
    [Tags("Quotation")]
    [Route("[controller]")]
    public class QuotationController : BaseController
    {

        private readonly ApplicationDbContext _applicationDBContext;
        public QuotationController(ApplicationDbContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        [Tags("Thunes.Quotation")]
        [HttpPost(ThunesUrl.CreateQuotationUrl)]
        public object CreateQuotation(QuotationRequest request)
        {
            try
            {

                var SourceCurrency = _applicationDBContext.ImtCurrencies.Find(request.ImtSourceCurrencyId);
                var SourceCountry = _applicationDBContext.ImtCountries.Find(request.ImtSourceCountryId);
                var DestinationCurrency = _applicationDBContext.ImtCurrencies.Find(request.ImtDestinationCurrencyId);

                SourceOne SourceOne = new SourceOne
                {
                    currency = SourceCurrency.Code,
                    country_iso_code = SourceCountry.IsoCode
                };
                DestinationOne DestinationOne = new DestinationOne
                {
                    amount = (double?)((request.DestinationAmount == null) ? 0 : request.DestinationAmount),
                    currency = DestinationCurrency.Code,
                };

                CreateQuotationRequest QuotationRequest = new CreateQuotationRequest
                {
                    external_id = request.OrderId,
                    payer_id = request.PayerId,
                    mode = request.Mode,
                    transaction_type = request.TransactionType,
                    source = SourceOne,
                    destination = DestinationOne
                };

                ImtQuotation prepareData = new ImtQuotation
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

                _applicationDBContext.ImtQuotations.Add(prepareData);
                _applicationDBContext.SaveChanges();

                return this._thunesClient.QuotationAdapter().CreateQuotation(QuotationRequest);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Quotation")]
        [HttpGet(ThunesUrl.RetrieveAQuotationByIdUrl)]
        public object RetrieveAQuotationByIdUrl(ulong id)
        {
            try
            {
                return this._thunesClient.QuotationAdapter().GetQuotationById(id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }
        [Tags("Thunes.Quotation")]
        [HttpGet(ThunesUrl.RetrieveQuotationByExternalIdUrl)]
        public object GetByExternalId(ulong external_id)
        {
            try
            {
                return this._thunesClient.QuotationAdapter().GetRetrieveQuotationByExternalId(external_id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

    }

}