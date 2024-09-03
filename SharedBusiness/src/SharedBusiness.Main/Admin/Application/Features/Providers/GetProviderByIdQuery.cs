using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Providers
{
    public record GetProviderByIdQuery(uint id) : IRequest<ErrorOr<Provider>>;

    public class GetProviderByIdQueryValidator : AbstractValidator<GetProviderByIdQuery>
    {
        public GetProviderByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Provider ID is required");
        }
    }


    public class GetProviderByIdQueryHandler : ProviderBaseCommand, IRequestHandler<GetProviderByIdQuery, ErrorOr<Provider>>
    {
        private readonly IProviderRepository _repository;

        public GetProviderByIdQueryHandler(IProviderRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Provider>> Handle(GetProviderByIdQuery request, CancellationToken cancellationToken)
        {
            var provider = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (provider == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return provider;
        }
    }
}
