using Admin.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Payers;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Payers
{
    public class CreatePayerController(ILogger<CreatePayerController> logger, ICurrentUser currentUser)
    : PayerBaseController (logger, currentUser)
    {
        [Tags("Payers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(PayerRoutes.CreatePayerTemplate, Name = PayerRoutes.CreatePayerName)]
        public async Task<IActionResult> Create(CreatePayerCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-payer-request: {Name} {@UserId} {@Response}",
                    nameof(CreatePayerCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                payer => Ok(ToSuccess(Mapper.Map<PayerDto>(payer))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-payer-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response), cancellationToken);
            return response;
        }
    }
}
