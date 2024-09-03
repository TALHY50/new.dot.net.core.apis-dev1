using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionTypes;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.TransactionTypes
{
    public class GetTransactionTypeById(ILogger<GetTransactionTypeById> logger, ICurrentUser currentUser)
    : TransactionTypeBase(logger, currentUser)
    {
        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(TransactionTypeRoutes.GetTransactionTypeByIdTemplate, Name = TransactionTypeRoutes.GetTransactionTypeByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetTransactionTypeByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-transactionType-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetTransactionTypeByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                transactionType => Ok(ToSuccess(Mapper.Map<TransactionTypeDto>(transactionType))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-transactionType-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
