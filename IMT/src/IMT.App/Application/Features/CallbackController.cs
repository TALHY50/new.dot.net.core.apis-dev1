using Microsoft.AspNetCore.Mvc;
using Thunes.Request.Transaction.Transfer.CommonTransaction;

namespace IMT.App.Application.Features
{
    public class CallbackController : Controller
    {
        [HttpPost("/api/v1/callback")]
        public IActionResult Callback(MoneyTransferDTO transferDTO)
        {
            return View();
        }
    }
}
