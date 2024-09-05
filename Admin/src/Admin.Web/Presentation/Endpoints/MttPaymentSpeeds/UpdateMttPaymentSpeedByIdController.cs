using Admin.Web.Presentation.Routes;
using Admin.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.MttPaymentSpeeds;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.MttPaymentSpeeds
{
    public class UpdateMttPaymentSpeedByIdController : MttPaymentSpeedBaseController
    {
        public UpdateMttPaymentSpeedByIdController(ILogger<UpdateMttPaymentSpeedByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("MttPaymentSpeed")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(MttPaymentSpeedRoutes.UpdateMttPaymentSpeedTemplate, Name = MttPaymentSpeedRoutes.UpdateMttPaymentSpeedName)]
        [HttpPatch(MttPaymentSpeedRoutes.UpdateMttPaymentSpeedTemplate, Name = MttPaymentSpeedRoutes.UpdateMttPaymentSpeedName)]

        public async Task<IActionResult> Update(uint id, UpdateMttPaymentSpeedByIdCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-mttPaymentSpeed-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                mttPaymentSpeed => Ok(ToSuccess(Mapper.Map<MttPaymentSpeedDto>(mttPaymentSpeed))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-mttPaymentSpeed-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
