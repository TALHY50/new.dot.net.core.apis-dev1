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