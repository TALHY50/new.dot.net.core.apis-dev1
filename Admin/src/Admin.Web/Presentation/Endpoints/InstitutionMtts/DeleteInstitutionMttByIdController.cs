using Admin.Web.Presentation.Endpoints.InstitutionMtts;
using Admin.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.InstitutionMtts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.InstitutionMtts
{
    public class DeleteInstitutionMttById(ILogger<DeleteInstitutionMttById> logger, ICurrentUser currentUser)
    : InstitutionMttBaseController(logger, currentUser)
    {
        [Tags("InstitutionMtts")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(InstitutionMttRoutes.DeleteInstitutionMttTemplate, Name = InstitutionMttRoutes.DeleteInstitutionMttName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteInstitutionMttByIdCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-InstitutionMtt-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteInstitutionMttByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-InstitutionMtt-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
