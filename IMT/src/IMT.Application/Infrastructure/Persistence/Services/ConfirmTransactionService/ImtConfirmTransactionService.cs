
using IMT.Thunes;
using SharedLibrary.Persistence.Configurations;
using IMT.Application.Infrastructure.Utility;
using IMT.Application.Domain.Ports.Services.ConfirmTransaction;
using IMT.Thunes.Exception;
using IMT.Thunes.Response.Common;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.IMT;
using SharedLibrary.Interfaces;
using IMT.Application.Infrastructure.Persistence.Repositories.Quotation;
using IMT.Application.Domain.Ports.Repositories.ConfirmTransaction;
using IMT.Thunes.Request.ConfirmTrasaction;

namespace IMT.Application.Infrastructure.Persistence.Services.ConfirmTransactionService
{

#pragma warning disable CS8629 // Nullable value type may be null.
    public class ImtConfirmTransactionService : ImtProviderErrorDetailsRepository, IImtConfirmTransactionService
    {
        // public readonly ThunesClient _thunesClient = new(Env.GetString("THUNES_API_KEY"), Env.GetString("THUNES_API_SECRET"), Env.GetString("THUNES_BASE_URL"));
        public readonly ThunesClient _thunesClient = new("f1c4a4d9-2899-4f09-b9f5-c35f09df5ffd", "bed820bd-264b-4d0f-8148-9f56e0a8b55c", "https://api-mt.pre.thunes.com");

        public ImtConfirmTransactionService(ApplicationDbContext dbContext) : base(dbContext) 
        {
            DependencyContainer.Initialize();
        }
        public object ConfirmTrasaction(ConfirmTrasactionDTO trasactionDTO)
        {
            try
            {
                return _thunesClient.GetTransactionAdapter().ConfirmTransactionById(trasactionDTO.TrasactionId);
            }
            catch (ThunesException e)
            {
                ErrorStore(e.Errors, trasactionDTO);
                //return StatusCode(e.ErrorCode, e.Errors);
                return null;
            }
        }

        public void ErrorStore(List<ErrorsResponse> Errors, ConfirmTrasactionDTO trasactionDTO)
        {
            foreach (var error in Errors)
            {
                ImtProviderErrorDetail prepareData = new ImtProviderErrorDetail
                {
                    ErrorCode = error.code,
                    ErrorMessage = error.message,
                    ImtProviderId = trasactionDTO.ProviderId,
                    ReferenceId = trasactionDTO.TrasactionId,
                    Type = trasactionDTO.Type,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                Add(prepareData);
            }
        }


    }
}
