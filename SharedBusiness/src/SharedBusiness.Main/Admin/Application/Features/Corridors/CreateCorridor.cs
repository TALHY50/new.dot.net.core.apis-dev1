using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;

namespace SharedBusiness.Main.Admin.Application.Features.Corridors
{
    public record CreateCorridorCommand(
        uint? SourceCountryId,
        uint? DestinationCountryId,
        uint? SourceCurrencyId,
        uint? DestinationCurrencyId,
        uint? CompanyId,
        StatusValues Status) : IRequest<ErrorOr<Corridor>>;
    public class CreateCorridorCommandValidator : AbstractValidator<CreateCorridorCommand>
    {
        public CreateCorridorCommandValidator()
        {
            RuleFor(x => x.SourceCountryId).NotEmpty();
            RuleFor(x => x.DestinationCountryId).NotEmpty();
            RuleFor(x => x.SourceCurrencyId).NotEmpty();
            RuleFor(x => x.DestinationCurrencyId).NotEmpty();
        }
    }
    public class CreateCorridorCommandHandler(ILogger<CreateCorridorCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, ICorridorRepository repository)
        : CorridorBase, IRequestHandler<CreateCorridorCommand, ErrorOr<Corridor>>
    {
        private readonly ILogger<CreateCorridorCommandHandler> _logger = logger;
        public async Task<ErrorOr<Corridor?>> Handle(CreateCorridorCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var corridor = new Corridor
            {
                SourceCountryId = request.SourceCountryId,
                DestinationCountryId = request.DestinationCountryId,
                SourceCurrencyId = request.SourceCurrencyId,
                DestinationCurrencyId = request.DestinationCurrencyId,
                CompanyId = request.CompanyId,
                CreatedById = 1,
                UpdatedById = 2,
                Status = (byte) request.Status,
                CreatedAt = now,
                UpdatedAt = now,
            };
            var result = await transactionHandler.ExecuteWithTransactionAsync<Corridor>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(corridor, cancellationToken);
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
