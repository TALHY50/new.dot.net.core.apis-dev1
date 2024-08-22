using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.Notification.Notifications.Events;

namespace ADMIN.App.Application.Features.BusinessHourAndWeekend;

public class GetBusinessHourAndWeekendsController : ApiControllerBase
{
    // [Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetBusinessHourAndWeekendUrl, Name = Routes.GetBusinessHourAndWeekendName)]
    public async Task<ActionResult<ErrorOr<Event>>> Get()
    {
        return await Mediator.Send(new GetBusinessHourAndWeekendQuery()).ConfigureAwait(false);
    }

    public record GetBusinessHourAndWeekendQuery() : IQuery<ErrorOr<Event>>;

    internal sealed class GetBusinessHourAndWeekendsHandler() : IQueryHandler<GetBusinessHourAndWeekendQuery, ErrorOr<Event>>
    {
        // get all data 
        public Task<ErrorOr<Event>> Handle(GetBusinessHourAndWeekendQuery request, CancellationToken cancellationToken)
        {
            // ToDo
            // Get all item from db
            throw new NotImplementedException();
        }
    }




}
