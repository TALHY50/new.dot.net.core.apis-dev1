
using IMT.Application.Contracts.Requests.Quotation;
using IMT.Application.Contracts.Requests.SendMoiney;
using IMT.Application.Domain.Ports.Services.Quotation;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;

namespace IMT.Web.Controllers.SendMoney
{

    [ApiController]
    [Tags("Quotation")]
    [Route("[controller]")]
    public class SendMoneyController : BaseController
    {

        private readonly IImtQuotationService _quotationService;
        public SendMoneyController(IImtQuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        [Tags("Thunes.SendMoney")]
        [HttpPost(ThunesUrl.SendMoney)]
        public object SendMoney(SendMoneyRequest request)
        {

            // prepare create quotation
            QuotationRequest QuotationRequest = new QuotationRequest
            {

            };

            return null;
        }

    }
}