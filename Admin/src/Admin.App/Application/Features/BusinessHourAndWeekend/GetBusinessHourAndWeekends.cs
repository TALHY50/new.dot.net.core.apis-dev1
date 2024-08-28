using Ardalis.SharedKernel;
using ErrorOr;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using IMT.App.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

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
