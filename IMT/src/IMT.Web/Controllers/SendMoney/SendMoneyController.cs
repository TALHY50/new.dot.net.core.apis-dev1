
using IMT.Application.Contracts.Requests.SendMoiney;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;
using IMT.Application.Domain.Ports.Services.SendMoney;
using IMT.Thunes.Exception;

namespace IMT.Web.Controllers.SendMoney
{

    [ApiController]
    [Tags("Quotation")]
    [Route("[controller]")]
    public class SendMoneyController : BaseController
    {

        private readonly IImtSendMoneyService _send_money_service;
        public SendMoneyController(IImtSendMoneyService send_money_service)
        {
            _send_money_service = send_money_service;
        }

        [Tags("Thunes.SendMoney")]
        [HttpPost(ThunesUrl.SendMoney)]
        public object SendMoney(SendMoneyRequest request)
        {
            try
            {
                return _send_money_service.SendMoney(request);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode,e.Errors);
            }
        }

    }
}