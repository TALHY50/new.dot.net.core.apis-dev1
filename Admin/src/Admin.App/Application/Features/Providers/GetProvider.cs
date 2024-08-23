using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.Providers
{
    public class GetProviderController : ApiControllerBase
    {
        [Authorize]//(Policy = "HasPermission")]
        [HttpGet(Routes.GetProviderUrl, Name = Routes.GetProviderName)]
        public async Task<ActionResult<ErrorOr<Provider>>> Get()
        {
            return await Mediator.Send(new GetProviderQuery()).ConfigureAwait(false);
        }

        public record GetProviderQuery() : IQuery<ErrorOr<Provider>>;

        internal sealed class GetProviderHandler()
            : IQueryHandler<GetProviderQuery, ErrorOr<Provider>>
        {
            // get all data 
            public Task<ErrorOr<Provider>> Handle(GetProviderQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
