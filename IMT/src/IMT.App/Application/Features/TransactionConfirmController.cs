using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Services;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using Thunes.Exception;
using Thunes.Request.ConfirmTrasaction;
using Thunes.Response.Common;
using Thunes.Route;

namespace IMT.App.Application.Features
{
    [Tags("Thunes")]
    [ApiController]
    [Route("[controller]")]
    public class TransactionConfirmController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IImtConfirmTransactionService _imtConfirmTransactionService;

        public TransactionConfirmController(ApplicationDbContext context, IImtConfirmTransactionService imtConfirmTransactionService)
        {
            _imtConfirmTransactionService = imtConfirmTransactionService;
            _context = context;
        }
        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.ConfirmTransactionByIdUrl)]
        public object ConfirmTransactionById(uint id)
        {
            var trasactionDTO = new ConfirmTrasactionDTO
            {
                RemoteTrasactionId = id,
                Type = 2,
                ProviderId = 1
            };

            return ConfirmTransactionByTrasactionId(trasactionDTO);
        }

        [Tags("Thunes.Transaction")]
        [HttpPost(ThunesUrl.ConfirmTransactionByExternalIdUrl)]
        public object ConfirmTransactionByExternalId(string invoice_id)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().ConfirmTransactionByExternalId(invoice_id);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }


        private object ConfirmTransactionByTrasactionId(ConfirmTrasactionDTO trasactionDTO)
        {
            try
            {
                return _imtConfirmTransactionService.ConfirmTrasaction(trasactionDTO);
                //return _thunesClient.GetTransactionAdapter().ConfirmTransactionById(trasactionDTO.RemoteTrasactionId);
            }
            catch (ThunesException e)
            {
                //ErrorStore(e.Errors, trasactionDTO);
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }
        private void ErrorStore(List<ErrorsResponse> Errors, ConfirmTrasactionDTO trasactionDTO)
        {
            foreach (var error in Errors)
            {
                ProviderErrorDetail prepareData = new ProviderErrorDetail
                {
                    ErrorCode = error.code,
                    ErrorMessage = error.message,
                    ImtProviderId = trasactionDTO.ProviderId,
                    ReferenceId = trasactionDTO.RemoteTrasactionId,
                    Type = trasactionDTO.Type,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                _context.ImtProviderErrorDetails.Add(prepareData);
                _context.SaveChanges();
            }
        }
    }
}
