using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.Admin;

namespace Admin.App.Application.Features.HolidaySetting;

public class GetHolidaySettingByIdController : ApiControllerBase
{

    //[Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetHolidaySettingByIdUrl, Name = Routes.GetHolidaySettingByIdName)]
    public async Task<ActionResult<ErrorOr<BusinessHoursAndWeekends>>> Delete(GetHolidaySettingByIdCommand command, int Id)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }

    public record GetHolidaySettingByIdCommand(int Id) : IRequest<ErrorOr<BusinessHoursAndWeekends>>;

    public class GetHolidaySettingByIdCommandValidator : AbstractValidator<GetHolidaySettingByIdCommand>
    {
        public GetHolidaySettingByIdCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Business hour and weekend ID is required");
        }
    }

    internal sealed class GetHolidaySettingByIdHandler() : IRequestHandler<GetHolidaySettingByIdCommand, ErrorOr<BusinessHoursAndWeekends>>
    {
        public Task<ErrorOr<BusinessHoursAndWeekends>> Handle(GetHolidaySettingByIdCommand request, CancellationToken cancellationToken)
        {
            // ToDo 
            // Check this id is valid
            // Get id by model
            throw new NotImplementedException();
        }
    }



}
