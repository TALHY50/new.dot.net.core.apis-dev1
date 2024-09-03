using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.ServiceMethods;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.ServiceMethods
{
    public class UpdateServiceMethod : ServiceMethodBase
    {
        public UpdateServiceMethod(ILogger<UpdateServiceMethod> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("ServiceMethods")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(ServiceMethodRoutes.UpdateServiceMethodTemplate, Name = ServiceMethodRoutes.UpdateServiceMethodName)]
        [HttpPatch(ServiceMethodRoutes.UpdateServiceMethodTemplate, Name = ServiceMethodRoutes.UpdateServiceMethodName)]

        public async Task<IActionResult> Update(uint id, UpdateServiceMethodCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-service-method-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                serviceMethod => Ok(ToSuccess(Mapper.Map<ServiceMethodDto>(serviceMethod))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-service-method-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
