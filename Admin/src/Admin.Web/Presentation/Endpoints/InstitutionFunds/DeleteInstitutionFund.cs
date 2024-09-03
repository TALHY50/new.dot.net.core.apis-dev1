using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.InstitutionFunds;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.InstitutionFunds
{
    public class DeleteInstitutionFund(ILogger<DeleteInstitutionFund> logger, ICurrentUser currentUser)
        : InstitutionFundBase(logger, currentUser)
    {
        [Tags("InstitutionFunds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(InstitutionFundRoutes.DeleteInstitutionFundTemplate, Name = InstitutionFundRoutes.DeleteInstitutionFundName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteInstitutionFundCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-institution-fund-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteInstitutionFundCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-institution-fund-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
