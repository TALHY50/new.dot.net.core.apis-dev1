using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Countries;

public record GetCountriesQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<Common.Domain.Entities.Country>>>;

public class GetCountriesQueryValidator : AbstractValidator<GetCountriesQuery>
{
    public GetCountriesQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .When(x => x.PageNumber != 0)
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .When(x => x.PageNumber > 0)
            .When(x => x.PageSize != 0)
            .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
    }
}

    public class GetCountriesQueryHandler 
        : CountryBase, IRequestHandler<GetCountriesQuery, ErrorOr<List<Common.Domain.Entities.Country>>>
    {
        private readonly ICountryRepository _repository;

        public GetCountriesQueryHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Common.Domain.Entities.Country>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            List<Country>? countries;
            
            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                 countries = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);
                
            }
            else
            {
                 countries = await _repository.ListAsync(cancellationToken);
                
            }
          
            if (countries == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "Country not found!");
            }
            
            return countries;
        }
    }
