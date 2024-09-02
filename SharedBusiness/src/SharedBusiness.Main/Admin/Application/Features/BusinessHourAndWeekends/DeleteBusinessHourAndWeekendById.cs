using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;

//using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.BusinessHourAndWeekends
{

    public record DeleteBusinessHoursAndWeekendByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteBusinessHoursAndWeekendByIdCommandValidator : AbstractValidator<DeleteBusinessHoursAndWeekendByIdCommand>
    {
        public DeleteBusinessHoursAndWeekendByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteBusinessHoursAndWeekendByIdCommandHandler : BusinessHourAndWeekendBase, IRequestHandler<DeleteBusinessHoursAndWeekendByIdCommand, ErrorOr<bool>>
    {
        private readonly IBusinessHourAndWeekendRepository _repository;

        public DeleteBusinessHoursAndWeekendByIdCommandHandler(IBusinessHourAndWeekendRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteBusinessHoursAndWeekendByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var country = await _repository.GetByIdAsync(command.id);

                if (country == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
                }

                await _repository.DeleteAsync(country, cancellationToken);

            }

            return true;
        }
    }
}
