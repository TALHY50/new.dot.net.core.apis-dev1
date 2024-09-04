using Admin.Web.Presentation.Endpoints.Banks;
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Banks;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Banks
{
    public class UpdateBankByIdController : BankBaseController
    {
        public UpdateBankByIdController(ILogger<UpdateBankByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("Banks")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(BankRoutes.UpdateBankTemplate, Name = BankRoutes.UpdateBankName)]
        [HttpPatch(BankRoutes.UpdateBankTemplate, Name = BankRoutes.UpdateBankName)]

        public async Task<IActionResult> Update(uint id, UpdateBankByIdCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-bank-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                bank => Ok(ToSuccess(Mapper.Map<BankDto>(bank))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-bank-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
