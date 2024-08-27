using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace Admin.App.Application.Features.Regions
{
    public class CreateRegionController : ApiControllerBase
    {
        [Tags("Regions")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateRegionUrl, Name = Routes.CreateRegionName)]
        public async Task<ActionResult<ErrorOr<Region>>> Create(CreateRegionCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record CreateRegionCommand(
        string? Name) : IRequest<ErrorOr<Region>>;

    //internal sealed class CreateRegionCommandValidator : AbstractValidator<CreateRegionCommand>
    //{
    //    public CreateRegionCommandValidator()
    //    {
    //        RuleFor(v => v.Status)
    //            .NotEmpty()
    //            .WithMessage("Status is required.");
    //    }
    //}

    internal sealed class CreateRegionCommandHandler
        : IRequestHandler<CreateRegionCommand, ErrorOr<Region>>
    {
        private readonly IImtRegionRepository _repository;
        public CreateRegionCommandHandler(IImtRegionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<Region>> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @region = new Region
            {
                Name = request.Name,
                CompanyId = 0,
                Status = 1,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now,
            };

            return await _repository.AddAsync(@region);
        }
    }
}
