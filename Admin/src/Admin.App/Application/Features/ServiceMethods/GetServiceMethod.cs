using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;

namespace ADMIN.App.Application.Features.ServiceMethods
{
    public class GetServiceMethodController : ApiControllerBase
    {
        [Tags("ServiceMethod")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetServiceMethodUrl, Name = Routes.GetServiceMethodName)]
        public async Task<ActionResult<ErrorOr<List<ServiceMethod>>>> Get()
        {
            return await Mediator.Send(new GetServiceMethodQuery()).ConfigureAwait(false);
        }

        public record GetServiceMethodQuery() : IRequest<ErrorOr<List<ServiceMethod>>>;

        internal sealed class GetServiceMethodQueryHandler : IRequestHandler<GetServiceMethodQuery, ErrorOr<List<ServiceMethod>>>
        {
            private readonly IImtServiceMethodRepository _repository;

            public GetServiceMethodQueryHandler(IImtServiceMethodRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<List<ServiceMethod>>> Handle(GetServiceMethodQuery request, CancellationToken cancellationToken)
            {
                return _repository.All().ToList();
            }
        }
    }
}
