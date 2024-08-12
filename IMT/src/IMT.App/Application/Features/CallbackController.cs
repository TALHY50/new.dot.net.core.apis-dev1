using Microsoft.AspNetCore.Mvc;
using Thunes.Request.Transaction.Transfer.CommonTransaction;

namespace IMT.App.Application.Features
{
    public class CallbackController : Controller
    {
        [HttpPost("/api/v1/callback")]
        public IActionResult Callback(MoneyTransferDTO transferDTO)
        {
            //todo need to insert or update db according to the request
            return View();
        }
    }
}
