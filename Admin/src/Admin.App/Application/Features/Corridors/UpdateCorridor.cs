using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using System.ComponentModel.Design;
using SharedKernel.Main.Admin.Application.Interfaces.Repositories;
using SharedKernel.Main.IMT.Domain.Entities;

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
            return await Mediator.Send(commandWithId).ConfigureAwait(false);
        }
    }
    public record UpdateCorridorCommand(
        uint id,
        uint? SourceCountryId,
        uint? DestinationCountryId,
        uint? SourceCurrencyId,
        uint? DestinationCurrencyId,
        uint? CompanyId) : IRequest<ErrorOr<Corridor>>;

    internal sealed class UpdateCorridorValidator : AbstractValidator<UpdateCorridorCommand>
    {
        public UpdateCorridorValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Corridor Id is required");
        }
    }


    internal sealed class UpdateCorridorCommandHandler
        : IRequestHandler<UpdateCorridorCommand, ErrorOr<Corridor>>
    {
        private readonly IImtCorridorRepository _repository;
        public UpdateCorridorCommandHandler(IImtCorridorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Corridor>> Handle(UpdateCorridorCommand request, CancellationToken cancellationToken)
        {
            Corridor? entity = _repository.GetByUintId(request.id);
            var now = DateTime.UtcNow;
            if (entity != null)
            {
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
            }
            return await _repository.UpdateAsync(entity); 
        }
    }
}
