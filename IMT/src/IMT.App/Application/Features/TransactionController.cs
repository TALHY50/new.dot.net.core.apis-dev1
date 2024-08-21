using IMT.App.Application.Ports.Services;
using Microsoft.AspNetCore.Mvc;
using Thunes.Exception;
using Thunes.Request.Transaction.Transfer.CommonTransaction;
using Thunes.Route;

namespace IMT.App.Application.Features
{
    [Tags("Thunes")]
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : BaseController
    {
#pragma warning disable CS1717 // Assignment made to same variable
        private readonly IImtMoneyTransferService _transactionService;
        public TransactionController(IImtMoneyTransferService transactionService)
        {
            _transactionService = transactionService;
        }

        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.CreateTransactionUrl)]
        public Object TransactionPost(ulong id, MoneyTransferDTO request)
        {
            try
            {
              return  _transactionService.CreateTransactionByQuotationId(id, request);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }
        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.CreateTransactionFromQuotationExternalIdUrl)]
        public Object CreateTransactionFromQuotationExternalIdPost(string invoice_id, MoneyTransferDTO request)
        {
            try
            {
                return _transactionService.CreateTransactionByExternalId(invoice_id, request);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }
    }
}
