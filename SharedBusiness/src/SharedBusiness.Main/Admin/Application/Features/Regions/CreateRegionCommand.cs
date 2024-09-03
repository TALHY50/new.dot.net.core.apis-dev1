using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Admin.Weblication.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;

namespace SharedBusiness.Main.Admin.Application.Features.Regions
{
    //[Authorize]
    public record CreateRegionCommand(
        string? name,
        uint? companyId,
        StatusValues status
        ) : IRequest<ErrorOr<Region>>;


    public class CreateRegionCommandValidator : AbstractValidator<CreateRegionCommand>
    {
        public CreateRegionCommandValidator()
        {
            RuleFor(v => v.name).MaximumLength(50).RegionName();
            RuleFor(v => v.status).NotEmpty().IsInEnum();
        }
    }


    public class CreateRegionCommandHandler(ILogger<CreateRegionCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, IRegionRepository repository)
        : RegionBaseCommand, IRequestHandler<CreateRegionCommand, ErrorOr<Region>>
    {
        private readonly ILogger<CreateRegionCommandHandler> _logger = logger;

        public async Task<ErrorOr<Region>> Handle(CreateRegionCommand command, CancellationToken cancellationToken)
        {
            var region = new Region
            {
                Name = command.name,
                CompanyId = command.companyId ?? 1,
                Status = (byte) command.status,
                CreatedById = 0,
                UpdatedById = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await transactionHandler.ExecuteWithTransactionAsync<Region>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(region, cancellationToken);
                    return obj;

                }, dbContext, 3, cancellationToken
            );

            if (result.IsError)
            {
                return result;
            }

            return result.Value;
        }
    }
}
