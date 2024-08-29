using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Admin.App.Application.Features.Corridors
{
    public class DeleteCorridorController : ApiControllerBase
    {
        [Tags("Corridor")]
        // [Authorize]
        [HttpDelete(Routes.DeleteCorridorUrl, Name = Routes.DeleteCorridorName)]
        public async Task<ActionResult<ErrorOr<bool>>> DeleteCorridor(uint id)
        {
            var result = await Mediator.Send(new DeleteCorridorCommand(id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record DeleteCorridorCommand(uint id) : IRequest<ErrorOr<bool>>;

    internal sealed class DeleteCorridorCommandValidator : AbstractValidator<DeleteCorridorCommand>
    {
        public DeleteCorridorCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty();
        }
    }
    internal sealed class DeleteCorridorCommandHandler : IRequestHandler<DeleteCorridorCommand, ErrorOr<bool>>
    {
        private readonly IImtCorridorRepository _repository;
        public DeleteCorridorCommandHandler(IImtCorridorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCorridorCommand request, CancellationToken cancellationToken)
        {
            if (request.id > 0)
            {
                var entity = _repository.GetByUintId(request.id);

                if (entity == null)
                {
                    return Error.NotFound(code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString(), "Corridor not found!");
                }

                return await _repository.DeleteAsync(entity);
            }

            return Error.NotFound(code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString(), "Corridor not found!");
        }
    }
}
