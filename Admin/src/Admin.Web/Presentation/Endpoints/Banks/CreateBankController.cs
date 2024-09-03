using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Banks;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.Banks
{
    public class CreateBankController(ILogger<CreateBankController> logger, ICurrentUser currentUser)
    : BankBaseController(logger, currentUser)
    {
        [Tags("Banks")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(BankRoutes.CreateBankTemplate, Name = BankRoutes.CreateBankName)]

        public async Task<IActionResult> Create(CreateBankCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-bank-request: {Name} {@UserId} {@Request}",
                    nameof(CreateBankCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                bank => Ok(ToSuccess(Mapper.Map<BankDto>(bank))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-bank-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
