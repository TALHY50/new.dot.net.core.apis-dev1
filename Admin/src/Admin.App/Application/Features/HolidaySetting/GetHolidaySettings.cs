using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<ActionResult<List<Entities.HolidaySetting>>> Get()
    {
        return await Mediator.Send(new GetHolidaySettingQuery()).ConfigureAwait(false);
    }

    public record GetHolidaySettingQuery() : IQuery<List<Entities.HolidaySetting>>;

    internal sealed class GetHolidaySettingsHandler(ImtApplicationDbContext _context, IHolidaySettingRepository repository) : IQueryHandler<GetHolidaySettingQuery, List<Entities.HolidaySetting>>
    {
        // get all data 
        public async Task<List<Entities.HolidaySetting>> Handle(GetHolidaySettingQuery request, CancellationToken cancellationToken)
        {
            // ToDo
            // Get all item from db
            var holidaySetting = await _context.ImtHolidaySettings.ToListAsync(cancellationToken);
            return holidaySetting;
        }
    }




}
