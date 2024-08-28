using ErrorOr;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Application.Features.Providers
{
    public class GetProviderController : ApiControllerBase
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetProviderUrl, Name = Routes.GetProviderName)]
        public async Task<ActionResult<ErrorOr<List<Provider>>>> Get()
        {
            return await Mediator.Send(new GetProviderQuery()).ConfigureAwait(false);
        }

        public record GetProviderQuery() : IRequest<ErrorOr<List<Provider>>>;

        internal sealed class GetProviderHandler
            : IRequestHandler<GetProviderQuery, ErrorOr<List<Provider>>>
        {
            private readonly IImtProviderRepository _providerRepository;
            public GetProviderHandler(IImtProviderRepository providerRepository)
            {
                _providerRepository = providerRepository;
            }
            public async Task<ErrorOr<List<Provider>>> Handle(GetProviderQuery request, CancellationToken cancellationToken)
            {
                return _providerRepository.All().ToList();
            }
        }
    }
}
