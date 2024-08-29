using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace ADMIN.App.Application.Features.ServiceMethods
{
    public class GetServiceMethodController : ApiControllerBase
    {
        [Tags("ServiceMethod")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetServiceMethodUrl, Name = Routes.GetServiceMethodName)]
        public async Task<ActionResult<ErrorOr<List<ServiceMethod>>>> Get()
        {
            var result = await Mediator.Send(new GetServiceMethodQuery()).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetServiceMethodQuery() : IRequest<ErrorOr<List<ServiceMethod>>>;

        public class GetServiceMethodQueryHandler : IRequestHandler<GetServiceMethodQuery, ErrorOr<List<ServiceMethod>>>
        {
            private readonly IImtServiceMethodRepository _repository;

            public GetServiceMethodQueryHandler(IImtServiceMethodRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<List<ServiceMethod>>> Handle(GetServiceMethodQuery request, CancellationToken cancellationToken)
            {
                var serviceMethods = _repository.All().ToList();

                if (serviceMethods == null)
                {
                    return Error.NotFound(code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString(), "Service Method not found!");
                }

                return serviceMethods;
            }
        }
    }
}
