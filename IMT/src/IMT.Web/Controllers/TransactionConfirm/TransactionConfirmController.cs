using IMT.Thunes.Exception;
using IMT.Thunes.Response.Common;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using SharedLibrary.Models.IMT;
using SharedLibrary.Persistence.Configurations;

namespace IMT.Web.Controllers.Transaction
{
    [Tags("Thunes")]
    [ApiController]
    [Route("[controller]")]
    public class TransactionConfirmController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public TransactionConfirmController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.ConfirmTransactionByIdUrl)]
        public object ConfirmTransactionById(int id)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().ConfirmTransactionById(id);
            }
            catch (ThunesException e)
            {
                ErrorStore(e.Errors,id);
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.ConfirmTransactionByExternalIdUrl)]
        public object ConfirmTransactionByExternalId(int external_id)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().ConfirmTransactionByExternalId(external_id);
            }
            catch (ThunesException e)
            {
                ErrorStore(e.Errors, external_id);
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

        private void ErrorStore(List<ErrorsResponse> Errors,int id)
        {
            foreach (var error in Errors)
            {
                ImtProviderErrorDetail prepareData = new ImtProviderErrorDetail
                {
                    ErrorCode = error.code,
                    ErrorMessage = error.message,
                    ImtProviderId = 1,
                    ReferenceId = id,
                    Type = 2,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                _context.ImtProviderErrorDetails.Add(prepareData);
                _context.SaveChanges();
            }
        }
    }
}
