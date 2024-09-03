using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Weblication.Features.Countries;
using SharedBusiness.Main.Admin.Weblication.Features.TransactionTypes;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.TransactionTypes
{
    public class CreateTransactionType(ILogger<CreateTransactionType> logger, ICurrentUser currentUser)
    : TransactionTypeBase(logger, currentUser)
    {
        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(TransactionTypeRoutes.CreateTransactionTypeTemplate, Name = TransactionTypeRoutes.CreateTransactionTypeName)]

        public async Task<IActionResult> Create(CreateTransactionTypeCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-transactionType-request: {Name} {@UserId} {@Request}",
                    nameof(CreateTransactionTypeCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                transactionType => Ok(ToSuccess(Mapper.Map<TransactionTypeDto>(transactionType))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-transactionType-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
