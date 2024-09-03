using Castle.Core.Logging;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Admin.Application.Features.ServiceMethods
{
    public record DeleteServiceMethodByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteServiceMethodCommandValidator : AbstractValidator<DeleteServiceMethodByIdCommand>
    {
        public DeleteServiceMethodCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteServiceMethodCommandHandler : ServiceMethodBase, IRequestHandler<DeleteServiceMethodByIdCommand, ErrorOr<bool>>
    {
        private readonly IServiceMethodRepository _repository;

        public DeleteServiceMethodCommandHandler(IServiceMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteServiceMethodByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var serviceMethod = await _repository.GetByIdAsync(command.id);

                if (serviceMethod == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
                }

                await _repository.DeleteAsync(serviceMethod, cancellationToken);

            }

            return true;
        }
    }
}
