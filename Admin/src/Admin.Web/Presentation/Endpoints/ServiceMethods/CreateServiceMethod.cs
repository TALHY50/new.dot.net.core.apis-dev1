using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.ServiceMethods;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.ServiceMethods
{
    public class CreateServiceMethod(ILogger<CreateServiceMethod> logger, ICurrentUser currentUser)
        : ServiceMethodBase(logger, currentUser)
    {
        [Tags("ServiceMethods")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(ServiceMethodRoutes.CreateServiceMethodTemplate, Name = ServiceMethodRoutes.CreateServiceMethodName)]

        public async Task<IActionResult> Create(CreateServiceMethodCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-service-method-request: {Name} {@UserId} {@Request}",
                    nameof(CreateServiceMethodCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                serviceMethod => Ok(ToSuccess(Mapper.Map<ServiceMethodDto>(serviceMethod))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-service-method-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
