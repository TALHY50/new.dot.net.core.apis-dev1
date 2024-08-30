using ErrorOr;
using MediatR;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;

namespace SharedBusiness.Main.Admin.Application.Features.Countries;

public record GetCountriesQuery() : IRequest<ErrorOr<List<Common.Domain.Entities.Country>>>;

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
            var countries = await _repository.ListAsync(cancellationToken);
            if (countries == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "Country not found!");
            }
            return countries;
        }
    }
