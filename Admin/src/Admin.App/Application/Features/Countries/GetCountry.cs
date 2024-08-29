using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.Countries
{
    public class GetCountryController : ApiControllerBase
    {
        [Tags("Country")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetCountryUrl, Name = Routes.GetCountryName)]
        public async Task<ActionResult<ErrorOr<List<Country>>>> Get()
        {
            var result = await Mediator.Send(new GetCountryQuery()).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetCountryQuery() : IRequest<ErrorOr<List<Country>>>;

        public class GetCountryQueryHandler 
            : IRequestHandler<GetCountryQuery, ErrorOr<List<Country>>>
        {
            private readonly IAdminCountryRepository _repository;

            public GetCountryQueryHandler(IAdminCountryRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<List<Country>>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
            {
                var countries = _repository.ViewAll();
                return countries;
            }
        }
    }
}
