using ACL.App.Contracts.Responses;
using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;
using static Admin.App.Application.Features.Mtts.InstitutionView;
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
                var provider = _providerRepository.View(request.id);
                if (provider == null)
                {
                    return Error.NotFound(description: Language.GetMessage("Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return provider;
            }
        }
    }

}
