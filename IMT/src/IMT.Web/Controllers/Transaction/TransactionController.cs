using IMT.Thunes.Exception;
using IMT.Thunes.Request.Transaction.Transfer.CommonTransaction;
using IMT.Thunes.Route;
using IMT.Thunes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IMT.Application.Domain.Ports.Services.Quotation;
using IMT.Application.Domain.Ports.Services.ConfirmTransaction;
using IMT.Application.Domain.Ports.Services.Transaction;

namespace IMT.Web.Controllers.Transaction
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
        public Object CreateTransactionFromQuotationExternalIdPost(int external_id, MoneyTransferDTO request)
        {
            try
            {
                return _transactionService.CreateTransactionByExternalId(external_id, request);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }
    }
}
