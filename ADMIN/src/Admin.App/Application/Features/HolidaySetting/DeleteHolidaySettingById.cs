using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.Admin;
using Entities = SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.HolidaySetting;

public class DeleteHolidaySettingByIdController : ApiControllerBase
{
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(Routes.DeleteHolidaySettingUrl, Name = Routes.DeleteHolidaySettingName)]
    public async Task<ActionResult<ErrorOr<Entities.HolidaySetting>>> Delete(DeleteHolidaySettingCommand command, int id)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }

    public record DeleteHolidaySettingCommand(int Id) : IRequest<ErrorOr<Entities.HolidaySetting>>;

    public class DeleteHolidaySettingCommandValidator : AbstractValidator<DeleteHolidaySettingCommand>
    {
        public DeleteHolidaySettingCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Setting holiday ID is required");
        }
    }

    internal sealed class DeleteHolidaySettingCommandHandler() : IRequestHandler<DeleteHolidaySettingCommand, ErrorOr<Entities.HolidaySetting>>
    {
        public Task<ErrorOr<Entities.HolidaySetting>> Handle(DeleteHolidaySettingCommand request, CancellationToken cancellationToken)
        {

            // ToDo delete logic

            throw new NotImplementedException();
        }
    }




}
