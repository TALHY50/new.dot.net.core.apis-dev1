using Admin.Web.Presentation.Routes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Features.ServiceMethods;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.Web.Presentation.Endpoints.ServiceMethods
{
    public class GetServiceMethodController(ILogger<GetServiceMethodController> logger, ICurrentUser currentUser)
        : ServiceMethodBase(logger, currentUser)
    {
        [Tags("ServiceMethods")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(ServiceMethodRoutes.GetServiceMethodTemplate, Name = ServiceMethodRoutes.GetServiceMethodName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetServiceMethodQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-service-method: {Name} {@UserId} {@Request}",
                    nameof(GetServiceMethodQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                serviceMethods => Ok(ToSuccess(serviceMethods.Select(serviceMethod => serviceMethod.Adapt<ServiceMethodDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-service-method-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
