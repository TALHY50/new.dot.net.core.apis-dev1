using Admin.Web.Presentation.Routes;
using Admin.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.MttPaymentSpeeds;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.MttPaymentSpeeds
{
    public class CreateMttPaymentSpeedController(ILogger<CreateMttPaymentSpeedController> logger, ICurrentUser currentUser)
        : MttPaymentSpeedBaseController(logger, currentUser)
    {
        [Tags("MttPaymentSpeeds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(MttPaymentSpeedRoutes.CreateMttPaymentSpeedTemplate, Name = MttPaymentSpeedRoutes.CreateMttPaymentSpeedName)]


        public async Task<IActionResult> Create(CreateMttPaymentSpeedCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-mttPaymentSpeed-request: {Name} {@UserId} {@Request}",
                    nameof(CreateMttPaymentSpeedCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                mttPaymentSpeed => Ok(ToSuccess(Mapper.Map<MttPaymentSpeedDto>(mttPaymentSpeed))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-mttPaymentSpeed-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
