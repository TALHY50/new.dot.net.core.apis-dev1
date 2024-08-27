using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Admin.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.IMT.Domain.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

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

    internal sealed class GetBusinessHourAndWeekendsHandler(ImtApplicationDbContext _context, IBusinessHourAndWeekendRepository repository) : IQueryHandler<GetBusinessHourAndWeekendQuery, List<BusinessHoursAndWeekend>>
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
