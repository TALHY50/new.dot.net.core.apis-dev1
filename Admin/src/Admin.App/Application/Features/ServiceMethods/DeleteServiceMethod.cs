using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Admin.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace ADMIN.App.Application.Features.ServiceMethods
{
    public class DeleteServiceMethodController : ApiControllerBase
    {
        [Tags("ServiceMethod")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteServiceMethodUrl, Name = Routes.DeleteServiceMethodName)]

        public async Task<ActionResult<bool>> Delete(DeleteServiceMethodCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record DeleteServiceMethodCommand(uint Id) : IRequest<bool>;

    internal sealed class DeleteServiceMethodCommandValidator : AbstractValidator<DeleteServiceMethodCommand>
    {
        public DeleteServiceMethodCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
        }
    }

    internal sealed class DeleteServiceMethodCommandHandler: IRequestHandler<DeleteServiceMethodCommand, bool>
    {
        private readonly IImtServiceMethodRepository _repository;

        public DeleteServiceMethodCommandHandler(IImtServiceMethodRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteServiceMethodCommand command, CancellationToken cancellationToken)
        {
            if (command.Id > 0)
            {
                var serviceMethod = _repository.GetByUintId(command.Id);

                if (serviceMethod != null)
                {
                    return await _repository.DeleteAsync(serviceMethod);
                }

                return await _repository.DeleteAsync(serviceMethod);
            }

            return false;
        }
    }
}