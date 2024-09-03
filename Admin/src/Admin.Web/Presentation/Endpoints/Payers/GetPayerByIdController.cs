using Admin.Web.Presentation.Endpoints.Corridors;
using Admin.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Corridors;
using SharedBusiness.Main.Admin.Application.Features.Payers;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Payers
{
    public class GetPayerByIdController(ILogger<GetPayerByIdController> logger, ICurrentUser currentUser)
    : PayerBaseController(logger, currentUser)
    {
        [Tags("Currencies")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(PayerRoutes.GetPayerByIdTemplate, Name = PayerRoutes.GetPayerByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetPayerByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-payer-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetPayerByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                payer => Ok(ToSuccess(Mapper.Map<PayerDto>(payer))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-payer-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
