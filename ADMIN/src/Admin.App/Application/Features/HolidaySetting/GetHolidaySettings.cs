using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.Admin;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using Entities = SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.HolidaySetting;

public class GetHolidaySettingsController : ApiControllerBase
{
    // [Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetHolidaySettingUrl, Name = Routes.GetHolidaySettingName)]
    public async Task<ActionResult<ErrorOr<Entities.HolidaySetting>>> Get()
    {
        return await Mediator.Send(new GetHolidaySettingQuery()).ConfigureAwait(false);
    }

    public record GetHolidaySettingQuery() : IQuery<ErrorOr<Entities.HolidaySetting>>;

    internal sealed class GetHolidaySettingsHandler(ImtApplicationDbContext context, IHolidaySettingRepository repository) : IQueryHandler<GetHolidaySettingQuery, ErrorOr<Entities.HolidaySetting>>
    {
        // get all data 
        public Task<ErrorOr<Entities.HolidaySetting>> Handle(GetHolidaySettingQuery request, CancellationToken cancellationToken)
        {
            // ToDo
            // Get all item from db
            throw new NotImplementedException();
        }
    }




}
