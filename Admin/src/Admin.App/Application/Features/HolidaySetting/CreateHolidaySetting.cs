﻿using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;
using Duplicates_HolidaySetting = SharedBusiness.Main.Common.Domain.Entities.HolidaySetting;


namespace Admin.App.Application.Features.HolidaySetting;

public class CreateHolidaySettingController : ApiControllerBase
{

    //[Authorize(Policy = "HasPermission")]
    [HttpPost(Routes.CreateHolidaySettingUrl, Name = Routes.CreateHolidaySettingName)]
    public async Task<ActionResult<ErrorOr<Duplicates_HolidaySetting>>> Create(CreateHolidaySettingCommand command)
    {
        var result = await Mediator.Send(command).ConfigureAwait(false);
        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }

    public record CreateHolidaySettingCommand(uint? CountryId, DateTime Date, byte Type, string Gmt, DateTime? OpenAt, DateTime? CloseAt, uint? CompanyId)
        : IRequest<ErrorOr<Duplicates_HolidaySetting>>;


    public class CreateHolidaySettingCommandValidator : AbstractValidator<CreateHolidaySettingCommand>
    {
        public CreateHolidaySettingCommandValidator()
        {
            RuleFor(r => r.Date).NotEmpty().WithMessage("Date is required.");
            RuleFor(r => r.Gmt).NotEmpty().WithMessage("Gmt is required.");
        }
    }

    public class CreateHolidaySettingHandler(ApplicationDbContext context, IHolidaySettingRepository repository) : IRequestHandler<CreateHolidaySettingCommand, ErrorOr<Duplicates_HolidaySetting>>
    {
        public async Task<ErrorOr<Duplicates_HolidaySetting>> Handle(CreateHolidaySettingCommand request, CancellationToken cancellationToken)
        {

            var entity = new Duplicates_HolidaySetting
            {
                CountryId = request.CountryId,
                Date = request.Date,
                Type = request.Type,
                Gmt = request.Gmt,
                OpenAt = request.OpenAt,
                CloseAt = request.CloseAt,
                CompanyId = request.CompanyId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            return await repository.AddAsync(entity);
        }
    }









}
