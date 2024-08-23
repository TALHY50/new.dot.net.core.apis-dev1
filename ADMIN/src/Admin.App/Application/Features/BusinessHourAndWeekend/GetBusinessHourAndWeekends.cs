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

namespace Admin.App.Application.Features.BusinessHourAndWeekend;

public class GetBusinessHourAndWeekendsController : ApiControllerBase
{
    // [Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetBusinessHourAndWeekendUrl, Name = Routes.GetBusinessHourAndWeekendName)]
    public async Task<ActionResult<ErrorOr<BusinessHoursAndWeekends>>> Get()
    {
        return await Mediator.Send(new GetBusinessHourAndWeekendQuery()).ConfigureAwait(false);
    }

    public record GetBusinessHourAndWeekendQuery() : IQuery<ErrorOr<BusinessHoursAndWeekends>>;

    internal sealed class GetBusinessHourAndWeekendsHandler(ImtApplicationDbContext context, IBusinessHourAndWeekendRepository repository) : IQueryHandler<GetBusinessHourAndWeekendQuery, ErrorOr<BusinessHoursAndWeekends>>
    {
        // get all data 
        public Task<ErrorOr<BusinessHoursAndWeekends>> Handle(GetBusinessHourAndWeekendQuery request, CancellationToken cancellationToken)
        {
            // ToDo
            // Get all item from db
            throw new NotImplementedException();
        }
    }




}
