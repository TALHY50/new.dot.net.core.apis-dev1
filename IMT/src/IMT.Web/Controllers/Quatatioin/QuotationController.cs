using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;
using IMT.Application.Contracts.Requests.Quotation;
using IMT.Application.Domain.Ports.Services.Quotation;
using IMT.Thunes;
using IMT.Thunes.Exception;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Request.Transaction.Quotation;
using IMT.Thunes.Response.Common;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models.IMT;
using SharedLibrary.Persistence.Configurations;
using SharedLibrary.Response.CustomStatusCode;

namespace IMT.Web.Controllers.Quotation
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
                if (_quotationService.IsValid(request))
                {
                    _quotationService.Add(_quotationService.PrepareImtQuotation(request));
                    return _quotationService.CreateQuotation(_quotationService.PrepareThunesCreateQuotationRequest(request));
                }
                return NotFound();
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