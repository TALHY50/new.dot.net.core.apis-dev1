using App.Application.Ports.Services;
using App.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using Thunes.Exception;
using Thunes.Route;

namespace App.Application.Features
{

    [ApiController]
    [Tags("Quotation")]
    [Route("[controller]")]
    public class QuotationController : BaseController
    {

#pragma warning disable CS1717 // Assignment made to same variable
        private readonly IImtQuotationService _quotationService;
        public QuotationController(IImtQuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        [Tags("Thunes.Quotation")]
        [HttpPost(ThunesUrl.CreateQuotationUrl)]
        public object CreateQuotation(QuotationRequest request)
        {
            try
            {
               return _quotationService.CreateQuotationCombined(request);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Quotation")]
        [HttpGet(ThunesUrl.RetrieveAQuotationByIdUrl)]
        public object RetrieveAQuotationById(ulong id)
        {
            try
            {
                return _quotationService.GetQuotationById(id);
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
                return _quotationService.GetQuotationByExternalId(external_id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

    }

}