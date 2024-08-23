using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;

namespace ADMIN.App.Application.Features.ServiceMethods
{
    public class GetServiceMethodController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetServiceMethodUrl, Name = Routes.GetServiceMethodName)]
        public async Task<ActionResult<ErrorOr<ServiceMethod>>> Get()
        {
            return await Mediator.Send(new GetServiceMethodQuery()).ConfigureAwait(false);
        }

        public record GetServiceMethodQuery() : IQuery<ErrorOr<ServiceMethod>>;

        internal sealed class GetServiceMethodQueryHandler() : IQueryHandler<GetServiceMethodQuery, ErrorOr<ServiceMethod>>
        {
            // get all data 
            public Task<ErrorOr<ServiceMethod>> Handle(GetServiceMethodQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
