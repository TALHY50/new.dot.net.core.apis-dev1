using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;
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

    public class DeleteCorridorCommandValidator : AbstractValidator<DeleteCorridorCommand>
    {
        public DeleteCorridorCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty();
        }
    }
    public class DeleteCorridorCommandHandler : IRequestHandler<DeleteCorridorCommand, ErrorOr<bool>>
    {
        private readonly ICorridorRepository _repository;
        public DeleteCorridorCommandHandler(ICorridorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCorridorCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageResponse("Record not found");
            if (request.id > 0)
            {
                var entity = _repository.FindById(request.id);

                if (entity == null)
                {
                    return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return _repository.Delete(entity);
            }

            return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
        }
    }
}
