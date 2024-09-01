using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.Corridors
{
    public class UpdateCorridorController : ApiControllerBase
    {
        [Tags("Corridor")]
        //[Authorize]//(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateCorridorUrl, Name = Routes.UpdateCorridorName)]

        public async Task<ActionResult<ErrorOr<Corridor>>> Update(uint id, UpdateCorridorCommand command)
        {
            var commandWithId = command with { id = id };
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record UpdateCorridorCommand(
        uint id,
        uint? SourceCountryId,
        uint? DestinationCountryId,
        uint? SourceCurrencyId,
        uint? DestinationCurrencyId,
        uint? CompanyId) : IRequest<ErrorOr<Corridor>>;

    public class UpdateCorridoryCommandValidator : AbstractValidator<UpdateCorridorCommand>
    {
        public UpdateCorridoryCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Corridor id is required");
            RuleFor(x => x.SourceCountryId).NotEmpty();
            RuleFor(x => x.DestinationCountryId).NotEmpty();
            RuleFor(x => x.SourceCurrencyId).NotEmpty();
            RuleFor(x => x.DestinationCurrencyId).NotEmpty();
        }
    }
    public class UpdateCorridorCommandHandler
        : IRequestHandler<UpdateCorridorCommand, ErrorOr<Corridor>>
    {
        private readonly ICorridorRepository _repository;
        public UpdateCorridorCommandHandler(ICorridorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Corridor>> Handle(UpdateCorridorCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageResponse("Record not found");
            Corridor? entity = _repository.FindById(request.id);
            var now = DateTime.UtcNow;
            if (entity == null)
            {
                return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            entity.SourceCountryId = request.SourceCountryId;
            entity.DestinationCountryId = request.DestinationCountryId;
            entity.SourceCurrencyId = request.SourceCurrencyId;
            entity.DestinationCurrencyId = request.DestinationCurrencyId;
            entity.CompanyId = request.CompanyId;
            entity.CreatedById = 1;
            entity.UpdatedById = 2;
            entity.Status = 1;
            entity.CreatedAt = now;
            entity.UpdatedAt = now;
            return _repository.Update(entity); 
        }
    }
}
