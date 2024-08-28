using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;
using static Admin.App.Application.Features.Mtts.MttView;
using static Admin.App.Application.Features.Providers.GetProviderController;
using static Admin.App.Application.Features.Regions.GetRegionByIdController;

namespace Admin.App.Application.Features.Providers
{
    public class GetProviderByIdController : ApiControllerBase
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetProviderByIdUrl, Name = Routes.GetProviderByIdName)]
        public async Task<ActionResult<ErrorOr<Provider>>> Get(uint id)
        {
            var result = await Mediator.Send(new GetProviderByIdQuery(id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetProviderByIdQuery(uint id) : IRequest<ErrorOr<Provider>>;


        public class GetProviderByIdCommandValidator : AbstractValidator<GetProviderByIdQuery>
        {
            public GetProviderByIdCommandValidator()
            {
                RuleFor(x => x.id)
                    .NotEmpty()
                    .WithMessage("ID is required");
            }
        }


        public class GetProviderByIdQueryValidator : AbstractValidator<GetProviderByIdQuery>
        {
            public GetProviderByIdQueryValidator()
            {
                RuleFor(x => x.id)
                    .NotEmpty()
                    .WithMessage("Provider ID is required");
            }
        }

        public class GetProviderByIdQueryHandler
            : IRequestHandler<GetProviderByIdQuery, ErrorOr<Provider>>
        {
            private readonly IImtProviderRepository _providerRepository;

            public GetProviderByIdQueryHandler(IImtProviderRepository providerRepository)
            {
                _providerRepository = providerRepository;
            }
            public async Task<ErrorOr<Provider>> Handle(GetProviderByIdQuery request, CancellationToken cancellationToken)
            {
                var provider = _providerRepository.GetByUintId(request.id);
                if (provider == null)
                {
                    return Error.NotFound(description: "Provider not found", code: AppStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
                else
                {
                    return provider;
                }
            }
        }
    }

}
