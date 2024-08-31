﻿using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using Duplicates_HolidaySetting = SharedBusiness.Main.Common.Domain.Entities.HolidaySetting;


namespace Admin.App.Application.Features.HolidaySetting;

public class GetHolidaySettingsController : ApiControllerBase
{
    // [Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetHolidaySettingUrl, Name = Routes.GetHolidaySettingName)]
    public async Task<ActionResult<List<Duplicates_HolidaySetting>>> Get()
    {
        return await Mediator.Send(new GetHolidaySettingQuery()).ConfigureAwait(false);
    }

    public record GetHolidaySettingQuery() : IQuery<List<Duplicates_HolidaySetting>>;

    internal sealed class GetHolidaySettingsHandler(ApplicationDbContext _context, IHolidaySettingRepository repository) : IQueryHandler<GetHolidaySettingQuery, List<Duplicates_HolidaySetting>>
    {
        // get all data 
        public async Task<List<Duplicates_HolidaySetting>> Handle(GetHolidaySettingQuery request, CancellationToken cancellationToken)
        {
            // ToDo
            // Get all item from db
            var holidaySetting = await _context.ImtHolidaySettings.ToListAsync(cancellationToken);
            return holidaySetting;
        }
    }




}
