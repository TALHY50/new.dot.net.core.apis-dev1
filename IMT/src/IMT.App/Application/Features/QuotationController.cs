using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Services;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Contracts.Requests;
using Thunes.Exception;
using Thunes.Route;

namespace IMT.App.Application.Features
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
        public object GetByExternalId(string invoice_id)
        {
            try
            {
                return _quotationService.GetQuotationByExternalId(invoice_id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

    }

}