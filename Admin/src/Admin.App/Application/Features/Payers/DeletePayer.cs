using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Admin.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Application.Features.Payers
{
    public class DeletePayerController : ApiControllerBase
    {
        [Tags("Payer")]
        // [Authorize]
        [HttpDelete(Routes.DeletePayerUrl, Name = Routes.DeletePayerName)]
        public async Task<bool> DeletePayer(uint id)
        {
            return await Mediator.Send(new DeletePayerCommand(id)).ConfigureAwait(false);
        }
    }

    public record DeletePayerCommand(uint id) : IRequest<bool>;

    internal sealed class DeletePayerCommandValidator : AbstractValidator<DeletePayerCommand>
    {
        public DeletePayerCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty();
        }
    }
    internal sealed class DeletePayerCommandHandler : IRequestHandler<DeletePayerCommand, bool>
    {
        private readonly IImtPayerRepository _repository;
        public DeletePayerCommandHandler(IImtPayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeletePayerCommand request, CancellationToken cancellationToken)
        {
            if (request.id > 0)
            {
                var entity = _repository.GetByUintId(request.id);

                if (entity != null)
                {
                    return await _repository.DeleteAsync(entity);
                }

                return await _repository.DeleteAsync(entity);
            }

            return false;
        }
    }
}
