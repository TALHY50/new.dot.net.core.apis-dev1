using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Countries
{
    
    public record GetCountryByIdQuery(uint id) : IRequest<ErrorOr<Common.Domain.Entities.Country>>;

        public class GetCountryByIdQueryValidator : AbstractValidator<GetCountryByIdQuery>
        {
            public GetCountryByIdQueryValidator()
            {
                RuleFor(x => x.id).NotEmpty().WithMessage("Country ID is required");
            }
        }

        public class GetCountryByIdQueryHandler : CountryBase, IRequestHandler<GetCountryByIdQuery, ErrorOr<Common.Domain.Entities.Country>>
        {
            private readonly ICountryRepository _repository;

            public GetCountryByIdQueryHandler(ICountryRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<Common.Domain.Entities.Country>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
            {
                var country = await _repository.GetByIdAsync(request.id, cancellationToken);

                if (country == null)
                {
                    return Error.NotFound(description: "Country not found!", code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return country;
            }
        }
    }

