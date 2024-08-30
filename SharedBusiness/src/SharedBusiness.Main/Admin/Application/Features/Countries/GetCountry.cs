using ErrorOr;
using MediatR;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;

namespace SharedBusiness.Main.Admin.Application.Features.Countries;

public record GetCountryQuery() : IRequest<ErrorOr<List<Common.Domain.Entities.Country>>>;

    public class GetCountryQueryHandler 
        : CountryBase, IRequestHandler<GetCountryQuery, ErrorOr<List<Common.Domain.Entities.Country>>>
    {
        private readonly ICountryRepository _repository;

        public GetCountryQueryHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Common.Domain.Entities.Country>>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            var countries = _repository.GetAll();
            if (countries == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "Country not found!");
            }
            return countries;
        }
    }
