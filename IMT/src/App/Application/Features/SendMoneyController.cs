using IMT.Application.Application.Ports.Services;
using IMT.Application.Contracts.Requests;
using IMT.Thunes.Exception;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;

namespace IMT.Application.Application.Features
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