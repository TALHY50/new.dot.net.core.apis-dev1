using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;
using static Admin.App.Application.Features.Providers.GetProviderController;

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
            private readonly IProviderRepository _providerRepository;

            public GetProviderByIdQueryHandler(IProviderRepository providerRepository)
            {
                _providerRepository = providerRepository;
            }
            public async Task<ErrorOr<Provider>> Handle(GetProviderByIdQuery request, CancellationToken cancellationToken)
            {
                var message = new MessageResponse("Record not found");

                var provider = _providerRepository.View(request.id);
                if (provider == null)
                {
                    return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
                else
                {
                    return provider;
                }
            }
        }
    }

}
