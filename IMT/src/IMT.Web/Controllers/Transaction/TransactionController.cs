using IMT.Thunes.Exception;
using IMT.Thunes.Request.Transaction.Transfer.CommonTransaction;
using IMT.Thunes.Route;
using IMT.Thunes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMT.Web.Controllers.Transaction
{
    [Tags("Thunes")]
    [ApiController]
    [Route("[controller]")]
    public class TransactionController :BaseController
    {
        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.CreateTransactionUrl)]
        public Object TransactionPost(ulong id, MoneyTransferDTO request)
        {
            try
            {
                var transactionType = _thunesClient.QuotationAdapter().GetQuotationById(id);
                if (request.IsValid(transactionType?.transaction_type?.ToLower()))
                {
                    return _thunesClient.GetTransactionAdapter().CreateTransaction(id, request);
                }
                return BadRequest("Request not valid");
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
                if (request.IsValid(null))
                {
                    return _thunesClient.GetTransactionAdapter().CreateTransactionFromQuotationExternalId(external_id, request);
                }
                return BadRequest("Request not valid");
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }
    }
}
