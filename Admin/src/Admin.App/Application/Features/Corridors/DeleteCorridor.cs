using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace Admin.App.Application.Features.Corridors
{
    public class DeleteCorridorController : ApiControllerBase
    {
        [Tags("Corridor")]
        // [Authorize]
        [HttpDelete(Routes.DeleteCorridorUrl, Name = Routes.DeleteCorridorName)]
        public async Task<bool> DeleteCorridor(uint id)
        {
            return await Mediator.Send(new DeleteCorridorCommand(id)).ConfigureAwait(false);
        }
    }

    public record DeleteCorridorCommand(uint id) : IRequest<bool>;

    internal sealed class DeleteCorridorCommandValidator : AbstractValidator<DeleteCorridorCommand>
    {
        public DeleteCorridorCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty();
        }
    }
    internal sealed class DeleteCorridorCommandHandler : IRequestHandler<DeleteCorridorCommand, bool>
    {
        private readonly IImtCorridorRepository _repository;
        public DeleteCorridorCommandHandler(IImtCorridorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCorridorCommand request, CancellationToken cancellationToken)
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
