﻿using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.Admin;

namespace ADMIN.App.Application.Features.HolidaySetting;

public class CreateHolidaySettingController : ApiControllerBase
{

    //[Authorize(Policy = "HasPermission")]
    [HttpPost(Routes.CreateHolidaySettingUrl, Name = Routes.CreateHolidaySettingName)]
    public async Task<ActionResult<ErrorOr<BusinessHoursAndWeekends>>> Create(CreateHolidaySettingCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }

    public record CreateHolidaySettingCommand(int? CountryId, DateTime Date, byte Type, sbyte Gmt, DateTime? OpenAt, DateTime? CloseAt, int CompanyId, byte Status)
        : IRequest<ErrorOr<BusinessHoursAndWeekends>>;


    internal sealed class CreateHolidaySettingCommandValidator : AbstractValidator<CreateHolidaySettingCommand>
    {
        public CreateHolidaySettingCommandValidator()
        {
            RuleFor(r => r.Date).NotEmpty();
            RuleFor(r => r.Gmt).NotEmpty();
        }
    }

    internal sealed class CreateHolidaySettingHandler() : IRequestHandler<CreateHolidaySettingCommand, ErrorOr<BusinessHoursAndWeekends>>
    {
        public Task<ErrorOr<BusinessHoursAndWeekends>> Handle(CreateHolidaySettingCommand request, CancellationToken cancellationToken)
        {

            //_context.Events.Add(@event);
            //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            throw new NotImplementedException();
        }
    }









}
