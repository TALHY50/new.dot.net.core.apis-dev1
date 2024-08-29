using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Application.Features.BusinessHourAndWeekend;

public class CreateBusinessHourAndWeekendController : ApiControllerBase
{

    //[Authorize(Policy = "HasPermission")]
    [HttpPost(Routes.CreateBusinessHourAndWeekendUrl, Name = Routes.CreateBusinessHourAndWeekendName)]
    public async Task<ActionResult<ErrorOr<BusinessHoursAndWeekend>>> Create(CreateBusinessHourAndWeekendCommand command)
    {
        var result = await Mediator.Send(command).ConfigureAwait(false);
        return result.Match(
            reminder => Ok(result.Value),
            Problem);

    }

    public record CreateBusinessHourAndWeekendCommand(byte HourType, uint? CountryId,
        string Day, sbyte IsWeekend, string Gmt, DateTime OpenAt, DateTime CloseAt, uint? CompanyId)
        : IRequest<ErrorOr<BusinessHoursAndWeekend>>;


    internal sealed class CreateBusinessHourAndWeekendCommandValidator : AbstractValidator<CreateBusinessHourAndWeekendCommand>
    {
        public CreateBusinessHourAndWeekendCommandValidator()
        {
            RuleFor(r => r.Day).NotEmpty().WithMessage("Day is required");
            RuleFor(r => r.OpenAt).NotEmpty().WithMessage("OpenAt is required");
            RuleFor(r => r.CloseAt).NotEmpty().WithMessage("CloseAt is required");
            RuleFor(r => r.Gmt).NotEmpty().WithMessage("Gmt is required");
            RuleFor(r => r.IsWeekend).NotEmpty().WithMessage("Gmt is required");
        }
    }

    internal sealed class CreateBusinessHourAndWeekendHandler(ApplicationDbContext context, IBusinessHourAndWeekendRepository repository) : IRequestHandler<CreateBusinessHourAndWeekendCommand, ErrorOr<BusinessHoursAndWeekend>>
    {

        public async Task<ErrorOr<BusinessHoursAndWeekend>> Handle(CreateBusinessHourAndWeekendCommand request, CancellationToken cancellationToken)
        {

            var entity = new BusinessHoursAndWeekend
            {
                HourType = request.HourType,
                CountryId = request.CountryId,
                Day = request.Day,
                IsWeekend = request.IsWeekend,
                Gmt = request.Gmt,
                OpenAt = request.OpenAt,
                CloseAt = request.CloseAt,
                CompanyId = request.CompanyId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            return await repository.AddAsync(entity);
        }
    }

}
