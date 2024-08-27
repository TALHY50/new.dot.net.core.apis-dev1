using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using static Admin.App.Application.Features.Mtts.MttView;

namespace Admin.App.Application.Features.Providers
{
    public class GetProviderByIdController : ApiControllerBase
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetProviderByIdUrl, Name = Routes.GetProviderByIdName)]
        public async Task<ActionResult<ErrorOr<Provider>>> Get(int id)
        {
            return await Mediator.Send(new GetProviderByIdQuery(id)).ConfigureAwait(false);
        }

        public record GetProviderByIdQuery(int id) : IRequest<ErrorOr<Provider>>;


        internal sealed class GetProviderByIdQueryValidator : AbstractValidator<GetProviderByIdQuery>
        {
            public GetProviderByIdQueryValidator()
            {
                RuleFor(x => x.id)
                    .NotEmpty()
                    .WithMessage("Provider ID is required");
            }
        }

        internal sealed class GetProviderByIdQueryHandler
            : IRequestHandler<GetProviderByIdQuery, ErrorOr<Provider>>
        {
            private readonly IImtProviderRepository _providerRepository;

            public GetProviderByIdQueryHandler(IImtProviderRepository providerRepository)
            {
                _providerRepository = providerRepository;
            }
            public async Task<ErrorOr<Provider>> Handle(GetProviderByIdQuery request, CancellationToken cancellationToken)
            {
                return _providerRepository.GetByIntId(request.id);
            }
        }
    }

}
