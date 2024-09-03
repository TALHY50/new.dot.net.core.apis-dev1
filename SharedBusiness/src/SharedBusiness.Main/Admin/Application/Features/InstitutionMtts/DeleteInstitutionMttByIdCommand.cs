using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;


namespace SharedBusiness.Main.Admin.Application.Features.InstitutionMtts
{
    public record DeleteInstitutionMttByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteInstitutionMttByIdCommandValidator : AbstractValidator<DeleteInstitutionMttByIdCommand>
    {
        public DeleteInstitutionMttByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteInstitutionMttByIdCommandHandler : InstitutionMttBase, IRequestHandler<DeleteInstitutionMttByIdCommand, ErrorOr<bool>>
    {
        private readonly IInstitutionMttRepository _repository;

        public DeleteInstitutionMttByIdCommandHandler(IInstitutionMttRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteInstitutionMttByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var institutionMtt = await _repository.GetByIdAsync(command.id);

                if (institutionMtt == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
                }

                await _repository.DeleteAsync(institutionMtt, cancellationToken);

            }

            return true;
        }
    }
}
