using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.Admin;

namespace ADMIN.App.Application.Features.BusinessHourAndWeekend;

public class UpdateBusinessHourAndWeekendController : ApiControllerBase
{
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(Routes.UpdateBusinessHourAndWeekendUrl, Name = Routes.UpdateBusinessHourAndWeekendName)]
    public async Task<ActionResult<ErrorOr<BusinessHoursAndWeekends>>> Create(UpdateBusinessHourAndWeekendCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }

    public record UpdateBusinessHourAndWeekendCommand(int id, byte HourType, int? CountryId,
    string Day, byte IsWeekend, sbyte Gmt, DateTime OpenAt, DateTime CloseAt, int CompanyId, byte Status)
    : IRequest<ErrorOr<BusinessHoursAndWeekends>>;


    internal sealed class UpdateBusinessHourAndWeekendCommandValidator : AbstractValidator<UpdateBusinessHourAndWeekendCommand>
    {
        public UpdateBusinessHourAndWeekendCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty();
        }
    }

    internal sealed class UpdateBusinessHourAndWeekendHandler() : IRequestHandler<UpdateBusinessHourAndWeekendCommand, ErrorOr<BusinessHoursAndWeekends>>
    {
        public Task<ErrorOr<BusinessHoursAndWeekends>> Handle(UpdateBusinessHourAndWeekendCommand request, CancellationToken cancellationToken)
        {

            // ToDo
            // First get the item from db
            // Then update current item
            throw new NotImplementedException();
        }
    }






}
