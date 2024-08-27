using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Admin.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.IMT.Domain.Entities;

namespace Admin.App.Application.Features.Countries
{
    public class GetCountryController : ApiControllerBase
    {
        [Tags("Country")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetCountryUrl, Name = Routes.GetCountryName)]
        public async Task<ActionResult<ErrorOr<List<Country>>>> Get()
        {
            return await Mediator.Send(new GetCountryQuery()).ConfigureAwait(false);
        }

        public record GetCountryQuery() : IRequest<ErrorOr<List<Country>>>;

        internal sealed class GetCountryQueryHandler 
            : IRequestHandler<GetCountryQuery, ErrorOr<List<Country>>>
        {
            private readonly IAdminCountryRepository _repository;

            public GetCountryQueryHandler(IAdminCountryRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<List<Country>>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
            {
                return _repository.All().ToList();
            }
        }
    }
}
