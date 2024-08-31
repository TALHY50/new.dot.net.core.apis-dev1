using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Admin.App.Application.Features.Providers
{
    public class GetProviderController : ApiControllerBase
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetProviderUrl, Name = Routes.GetProviderName)]
        public async Task<ActionResult<ErrorOr<List<Provider>>>> Get()
        {
            var result = await Mediator.Send(new GetProviderQuery()).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetProviderQuery() : IRequest<ErrorOr<List<Provider>>>;

        public class GetProviderHandler
            : IRequestHandler<GetProviderQuery, ErrorOr<List<Provider>>>
        {
            private readonly IProviderRepository _providerRepository;
            public GetProviderHandler(IProviderRepository providerRepository)
            {
                _providerRepository = providerRepository;
            }
            public async Task<ErrorOr<List<Provider>>> Handle(GetProviderQuery request, CancellationToken cancellationToken)
            {
                return _providerRepository.GetAll().ToList();
            }
        }
    }
}
