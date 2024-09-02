using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Regions
{
    public record UpdateRegionByIdCommand(
        uint id,
        string? name,
        uint? companyId,
        StatusValues status) : IRequest<ErrorOr<Region>>;


    public class UpdateRegionByIdCommandValidator : AbstractValidator<UpdateRegionByIdCommand>
    {
        public UpdateRegionByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Region ID is required");
            RuleFor(v => v.name).MaximumLength(50).RegionName();
            RuleFor(v => v.status).NotEmpty().IsInEnum();
        }
    }

    public class UpdateRegionByIdCommandHandler : RegionBase, IRequestHandler<UpdateRegionByIdCommand, ErrorOr<Region>>
    {
        private readonly IRegionRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateRegionByIdCommandHandler(IRegionRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<Region>> Handle(UpdateRegionByIdCommand command, CancellationToken cancellationToken)
        {
            Region? region = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (region == null)
            {
                return Error.NotFound(description: "Region not found",
                    code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => region.Name = value, command.name);
            _guard.UpdateIfNotNullOrEmpty(value => region.CompanyId = value, command.companyId);
          

            region.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(region, cancellationToken);

            return region;


        }

    }
}
