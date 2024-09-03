using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.ServiceMethods;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.ServiceMethods
{
    public class GetServiceMethodById(ILogger<GetServiceMethodById> logger, ICurrentUser currentUser)
        : ServiceMethodBase(logger, currentUser)
    {
        [Tags("ServiceMethods")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(ServiceMethodRoutes.GetServiceMethodByIdTemplate, Name = ServiceMethodRoutes.GetServiceMethodByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetServiceMethodByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-service-method-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetServiceMethodByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);

            var result = await Mediator.Send(query).ConfigureAwait(false);

            var response = result.Match(
                serviceMethod => Ok(ToSuccess(Mapper.Map<ServiceMethodDto>(serviceMethod))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-service-method-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
