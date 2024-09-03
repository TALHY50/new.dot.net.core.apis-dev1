
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.InstitutionMtts;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.InstitutionMtts
{
    public class UpdateInstitutionMttByIdController : InstitutionMttBaseController
    {
        public UpdateInstitutionMttByIdController(ILogger<UpdateInstitutionMttByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("InstitutionMtts")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(InstitutionMttRoutes.UpdateInstitutionMttTemplate, Name = InstitutionMttRoutes.UpdateInstitutionMttName)]
        [HttpPatch(InstitutionMttRoutes.UpdateInstitutionMttTemplate, Name = InstitutionMttRoutes.UpdateInstitutionMttName)]

        public async Task<IActionResult> Update(uint id, UpdateInstitutionMttByIdCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-InstitutionMtt-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                institutionMtt => Ok(ToSuccess(Mapper.Map<InstitutionMttDto>(institutionMtt))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-InstitutionMtt-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
