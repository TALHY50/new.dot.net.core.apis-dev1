using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.HolidaySetting;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.HolidaySettings;

public record DeleteHolidaySettingByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

public class DeleteHolidaySettingByIdCommandValidator : AbstractValidator<DeleteHolidaySettingByIdCommand>
{
    public DeleteHolidaySettingByIdCommandValidator()
    {
        RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
    }
}

public class DeleteHolidaySettingByIdCommandHandler : HolidaySettingBase, IRequestHandler<DeleteHolidaySettingByIdCommand, ErrorOr<bool>>
{
    private readonly IHolidaySettingRepository _repository;
    public DeleteHolidaySettingByIdCommandHandler(IHolidaySettingRepository repository)
    {
        _repository = repository;
    }
    public async Task<ErrorOr<bool>> Handle(DeleteHolidaySettingByIdCommand command, CancellationToken cancellationToken)
    {
        if (command.id > 0)
        {
            var holidaySetting = await _repository.GetByIdAsync(command.id);
            if (holidaySetting == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }
            await _repository.DeleteAsync(holidaySetting, cancellationToken);
        }
        return true;
    }
}
