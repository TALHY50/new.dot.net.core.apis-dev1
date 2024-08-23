using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.Admin;

using Entities = SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.HolidaySetting;

public class GetHolidaySettingByIdController : ApiControllerBase
{

    //[Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetHolidaySettingByIdUrl, Name = Routes.GetHolidaySettingByIdName)]
    public async Task<ActionResult<ErrorOr<Entities.HolidaySetting>>> Delete(GetHolidaySettingByIdCommand command, int Id)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }

    public record GetHolidaySettingByIdCommand(int Id) : IRequest<ErrorOr<Entities.HolidaySetting>>;

    public class GetHolidaySettingByIdCommandValidator : AbstractValidator<GetHolidaySettingByIdCommand>
    {
        public GetHolidaySettingByIdCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Business hour and weekend ID is required");
        }
    }

    internal sealed class GetHolidaySettingByIdHandler() : IRequestHandler<GetHolidaySettingByIdCommand, ErrorOr<Entities.HolidaySetting>>
    {
        public Task<ErrorOr<Entities.HolidaySetting>> Handle(GetHolidaySettingByIdCommand request, CancellationToken cancellationToken)
        {
            // ToDo 
            // Check this id is valid
            // Get id by model
            throw new NotImplementedException();
        }
    }



}
