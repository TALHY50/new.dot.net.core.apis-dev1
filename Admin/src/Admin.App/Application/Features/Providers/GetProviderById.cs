using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.Providers
{
    public class GetProviderByIdController : ApiControllerBase
    {
        [Authorize]//(Policy = "HasPermission")]
        [HttpGet(Routes.GetProviderByIdUrl, Name = Routes.GetProviderByIdName)]
        public async Task<ActionResult<ErrorOr<Provider>>> Get(int id)
        {
            return await Mediator.Send(new GetProviderByIdQuery(id)).ConfigureAwait(false);
        }

        public record GetProviderByIdQuery(int Id) : IRequest<ErrorOr<Provider>>;


        internal sealed class GetProviderByIdQueryHandler()
            : IRequestHandler<GetProviderByIdQuery, ErrorOr<Provider>>
        {
            // get all data 
            public Task<ErrorOr<Provider>> Handle(GetProviderByIdQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }

}
