
using IMT.Application.Domain.Ports.Services.Quotation;
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
    }
}