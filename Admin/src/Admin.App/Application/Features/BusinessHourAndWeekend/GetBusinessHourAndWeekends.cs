using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Admin.App.Application.Features.BusinessHourAndWeekend;

public class GetBusinessHourAndWeekendsController : ApiControllerBase
{
    // [Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetBusinessHourAndWeekendUrl, Name = Routes.GetBusinessHourAndWeekendName)]
    public async Task<ActionResult<List<BusinessHoursAndWeekend>>> Get()
    {
        return await Mediator.Send(new GetBusinessHourAndWeekendQuery()).ConfigureAwait(false);
    }

    public record GetBusinessHourAndWeekendQuery() : IQuery<List<BusinessHoursAndWeekend>>;

    internal sealed class GetBusinessHourAndWeekendsHandler(ApplicationDbContext _context, IBusinessHourAndWeekendRepository repository) : IQueryHandler<GetBusinessHourAndWeekendQuery, List<BusinessHoursAndWeekend>>
    {
        // get all data 
        public async Task<List<BusinessHoursAndWeekend>> Handle(GetBusinessHourAndWeekendQuery request, CancellationToken cancellationToken)
        {
            // ToDo
            // Get all item from db

            var businessHourAndWeekend = await _context.ImtBusinessHoursAndWeekends.ToListAsync(cancellationToken);
            return businessHourAndWeekend;
        }
    }




}
