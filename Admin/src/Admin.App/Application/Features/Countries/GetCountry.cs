using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Domain.Notification.Notifications.Events;

namespace Admin.App.Application.Features.Countries
{
    public class GetCountryController : ApiControllerBase
    {
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetCountryUrl, Name = Routes.GetCountryName)]
        public async Task<ActionResult<ErrorOr<List<Country>>>> Get()
        {
            return await Mediator.Send(new GetCountryQuery()).ConfigureAwait(false);
        }

        public record GetCountryQuery() : IQuery<ErrorOr<List<Country>>>;

        internal sealed class GetCountryQueryHandler 
            : IQueryHandler<GetCountryQuery, ErrorOr<List<Country>>>
        {
            private readonly IAdminCountryRepository _repository;

            public GetCountryQueryHandler(IAdminCountryRepository repository)
            {
                _repository = repository;
            }

            public Task<ErrorOr<List<Country>>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
            {
                var countries = _repository.All().ToList();
                return Task.FromResult<ErrorOr<List<Country>>>(countries);
            }
        }
    }
}
