using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using Entities = SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.HolidaySetting;

public class CreateHolidaySettingController : ApiControllerBase
{

    //[Authorize(Policy = "HasPermission")]
    [HttpPost(Routes.CreateHolidaySettingUrl, Name = Routes.CreateHolidaySettingName)]
    public async Task<ActionResult<ErrorOr<Entities.HolidaySetting>>> Create(CreateHolidaySettingCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }

    public record CreateHolidaySettingCommand(uint? CountryId, DateTime Date, byte Type, sbyte Gmt, DateTime? OpenAt, DateTime? CloseAt, uint? CompanyId)
        : IRequest<ErrorOr<Entities.HolidaySetting>>;


    internal sealed class CreateHolidaySettingCommandValidator : AbstractValidator<CreateHolidaySettingCommand>
    {
        public CreateHolidaySettingCommandValidator()
        {
            RuleFor(r => r.Date).NotEmpty().WithMessage("Date is required.");
            RuleFor(r => r.Gmt).NotEmpty().WithMessage("Gmt is required.");
        }
    }

    internal sealed class CreateHolidaySettingHandler(ImtApplicationDbContext context, IHolidaySettingRepository repository) : IRequestHandler<CreateHolidaySettingCommand, ErrorOr<Entities.HolidaySetting>>
    {
        public async Task<ErrorOr<Entities.HolidaySetting>> Handle(CreateHolidaySettingCommand request, CancellationToken cancellationToken)
        {

            var entity = new Entities.HolidaySetting
            {
                CountryId = request.CountryId,
                Date = request.Date,
                Type = request.Type,
                Gmt = request.Gmt,
                OpenAt = request.OpenAt,
                CloseAt = request.CloseAt,
                CompanyId = request.CompanyId
            };
            return await repository.AddAsync(entity);
        }
    }









}
