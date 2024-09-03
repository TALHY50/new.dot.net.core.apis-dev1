using Admin.Web.Presentation.Endpoints.Country;
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.TransactionTypes;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.TransactionTypes
{
    public class UpdateTransactionTypeByIdController : TransactionTypeBaseController
    {
        public UpdateTransactionTypeByIdController(ILogger<UpdateTransactionTypeByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(TransactionTypeRoutes.UpdateTransactionTypeTemplate, Name = TransactionTypeRoutes.UpdateTransactionTypeName)]
        [HttpPatch(TransactionTypeRoutes.UpdateTransactionTypeTemplate, Name = TransactionTypeRoutes.UpdateTransactionTypeName)]

        public async Task<IActionResult> Update(uint id, UpdateTransactionTypeByIdCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-transactionType-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                transactionType => Ok(ToSuccess(Mapper.Map<TransactionTypeDto>(transactionType))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-transactionType-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
