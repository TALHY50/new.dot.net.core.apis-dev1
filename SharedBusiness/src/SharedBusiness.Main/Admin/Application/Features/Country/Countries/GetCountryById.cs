using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;

namespace SharedBusiness.Main.Admin.Application.Features.Country.Countries
{
    public record GetCountryByIdQuery(uint Id) : IRequest<ErrorOr<IMT.Domain.Entities.Country>>;

    public class GetCountryByIdCommandValidator : AbstractValidator<GetCountryByIdQuery>
    {
        public GetCountryByIdCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Country ID is required");
        }
    }

    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, ErrorOr<IMT.Domain.Entities.Country>>
    {
        private readonly IAdminCountryRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetCountryByIdQueryHandler(IHttpContextAccessor httpContextAccessor, IAdminCountryRepository repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }
        public async Task<ErrorOr<IMT.Domain.Entities.Country>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = _repository.View(request.Id);

            if (country == null)
            {
                return Error.NotFound(description: Language.GetMessage("Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return country;
        }
    }
}

