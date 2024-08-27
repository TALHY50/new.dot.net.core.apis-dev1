using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.Providers
{
    public class GetProviderController : ApiControllerBase
    {
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetProviderUrl, Name = Routes.GetProviderName)]
        public async Task<ActionResult<ErrorOr<List<Provider>>>> Get()
        {
            return await Mediator.Send(new GetProviderQuery()).ConfigureAwait(false);
        }

        public record GetProviderQuery() : IQuery<ErrorOr<List<Provider>>>;

        internal sealed class GetProviderHandler
            : IQueryHandler<GetProviderQuery, ErrorOr<List<Provider>>>
        {
            private readonly IImtProviderRepository _providerRepository;
            public GetProviderHandler(IImtProviderRepository providerRepository)
            {
                _providerRepository = providerRepository;
            }
            public Task<ErrorOr<List<Provider>>> Handle(GetProviderQuery request, CancellationToken cancellationToken)
            {
                var providers = _providerRepository.All().ToList();
                return Task.FromResult<ErrorOr<List<Provider>>>(providers);
            }
        }
    }
}
