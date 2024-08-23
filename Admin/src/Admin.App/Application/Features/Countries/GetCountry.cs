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
        public async Task<ActionResult<List<Country>>> Get()
        {
            return await Mediator.Send(new GetCountryQuery()).ConfigureAwait(false);
        }

        public record GetCountryQuery() : IQuery<List<Country>>;

        internal sealed class GetCountryQueryHandler : IQuery<List<Country>>
        {
            private readonly IAdminCountryRepository _repository;

            public GetCountryQueryHandler(IAdminCountryRepository repository)
            {
                _repository = repository;
            }

            public Task<ErrorOr<List<Country>>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_repository.All().ToList().ToErrorOr());
            }
        }
    }
}
