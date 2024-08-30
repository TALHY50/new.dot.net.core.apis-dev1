using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;

namespace SharedBusiness.Main.Admin.Application.Features.Country.Countries;

public record GetCountryQuery() : IRequest<ErrorOr<List<IMT.Domain.Entities.Country>>>;

    public class GetCountryQueryHandler 
        : IRequestHandler<GetCountryQuery, ErrorOr<List<IMT.Domain.Entities.Country>>>
    {
        private readonly IAdminCountryRepository _repository;

    public GetCountryQueryHandler( IAdminCountryRepository repository)
    {
    _repository = repository;
    }

    public async Task<ErrorOr<List<IMT.Domain.Entities.Country>>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
    {
        var countries = _repository.ViewAll();
        if (countries == null)
        {
            return Error.NotFound(description: Language.GetMessage("Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
        }
        return countries;
    }
}
