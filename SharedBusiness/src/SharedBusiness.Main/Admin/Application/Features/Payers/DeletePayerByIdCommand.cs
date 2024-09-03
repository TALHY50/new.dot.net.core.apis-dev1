using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Admin.Application.Features.Payers;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Admin.Application.Features.Payers
{
    public record DeletePayerByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeletePayerByIdCommandValidator : AbstractValidator<DeletePayerByIdCommand>
    {
        public DeletePayerByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeletePayerByIdCommandHandler : PayerBase, IRequestHandler<DeletePayerByIdCommand, ErrorOr<bool>>
    {
        private readonly IPayerRepository _repository;

        public DeletePayerByIdCommandHandler(IPayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeletePayerByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var payer = await _repository.GetByIdAsync(command.id);

                if (payer == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
                }

                await _repository.DeleteAsync(payer, cancellationToken);

            }

            return true;
        }
    }
}
