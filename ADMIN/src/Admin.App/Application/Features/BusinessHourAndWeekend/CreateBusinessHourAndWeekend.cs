using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.Notification.Notifications.Events;

namespace ADMIN.App.Application.Features.BusinessHourAndWeekend;

public class CreateBusinessHourAndWeekendController : ApiControllerBase
{

    //[Authorize(Policy = "HasPermission")]
    [HttpPost(Routes.CreateBusinessHourAndWeekendUrl, Name = Routes.CreateBusinessHourAndWeekendName)]
    public async Task<ActionResult<ErrorOr<Event>>> Create(CreateBusinessHourAndWeekendCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }

    public record CreateBusinessHourAndWeekendCommand(byte HourType, int? CountryId,
        string Day, byte IsWeekend, sbyte Gmt, DateTime OpenAt, DateTime CloseAt, int CompanyId, byte Status)
        : IRequest<ErrorOr<Event>>;


    internal sealed class CreateBusinessHourAndWeekendCommandValidator : AbstractValidator<CreateBusinessHourAndWeekendCommand>
    {
        public CreateBusinessHourAndWeekendCommandValidator()
        {
            RuleFor(r => r.Day).NotEmpty();
        }
    }

    internal sealed class CreateBusinessHourAndWeekendHandler() : IRequestHandler<CreateBusinessHourAndWeekendCommand, ErrorOr<Event>>
    {
        public Task<ErrorOr<Event>> Handle(CreateBusinessHourAndWeekendCommand request, CancellationToken cancellationToken)
        {

            //_context.Events.Add(@event);
            //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            throw new NotImplementedException();
        }
    }









}
