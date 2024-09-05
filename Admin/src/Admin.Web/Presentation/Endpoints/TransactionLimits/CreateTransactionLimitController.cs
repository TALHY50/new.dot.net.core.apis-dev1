
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedKernel.Main.Application.Interfaces.Services;
using Admin.Web.Presentation.Routes;
using SharedBusiness.Main.Common.Contracts;


namespace Admin.Web.Presentation.Endpoints.TransactionLimits
{
    public class CreateTransactionLimitController(ILogger<CreateTransactionLimitController> logger, ICurrentUser currentUser) : TransactionLimitBaseController(logger, currentUser)
    {
        [Tags("TransactionLimits")]
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
