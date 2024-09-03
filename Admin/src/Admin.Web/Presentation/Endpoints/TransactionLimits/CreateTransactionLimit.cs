
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedKernel.Main.Application.Interfaces.Services;
using Admin.Web.Presentation.Routes;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;

namespace Admin.Web.Presentation.Endpoints.TransactionLimits
{
    public class CreateTransactionLimit(ILogger<CreateTransactionLimit> logger, ICurrentUser currentUser) : TransactionLimitBase(logger, currentUser)
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(TransactionLimitRoutes.CreateTransactionLimitTemplate, Name = TransactionLimitRoutes.CreateTransactionLimitName)]
        public async Task<IActionResult> Create(CreateTransactionLimitCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-transactionlimit-request: {Name} {@UserId} {@Request}",
                    nameof(CreateTransactionLimitCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                transactionLimit => Ok(ToSuccess(Mapper.Map<TransactionLimitDto>(transactionLimit))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-transactionlimit-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }

}
