using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;

namespace SharedBusiness.Main.Admin.Application.Features.InstitutionMtts
{
    public record CreateInstitutionMttCommand(
        uint InstitutionId,
        uint MttId,
        byte CommissionType,
        uint? CommissionCurrencyId,
        decimal CommissionPercentage,
        decimal CommissionFixed,
        uint? CompanyId,
        StatusValues Status) : IRequest<ErrorOr<InstitutionMtt>>;
    public class CreateInstitutionMttCommandValidator : AbstractValidator<CreateInstitutionMttCommand>
    {
        public CreateInstitutionMttCommandValidator()
        {
            RuleFor(x => x.InstitutionId).NotEmpty().WithMessage("InstitutionId is required");
            RuleFor(x => x.MttId).NotEmpty().WithMessage("MttId is required");
            RuleFor(x => x.CommissionType).NotEmpty().WithMessage("CommissionType is required");
            RuleFor(x => x.CommissionCurrencyId).NotEmpty().WithMessage("CommissionCurrencyId cannot be empty");
            RuleFor(x => x.CommissionPercentage).NotEmpty().WithMessage("CommissionPercentage is required");
            RuleFor(x => x.CommissionFixed).NotEmpty().WithMessage("CommissionFixed is required");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status is required");
            RuleFor(x => x.CompanyId).NotEmpty().CompanyIdRule();
        }
    }
    public class CreateInstitutionMttCommandHandler(ILogger<CreateInstitutionMttCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, IInstitutionMttRepository repository)
        : InstitutionMttBase, IRequestHandler<CreateInstitutionMttCommand, ErrorOr<InstitutionMtt>>
    {
        private readonly ILogger<CreateInstitutionMttCommandHandler> _logger = logger;
        public async Task<ErrorOr<InstitutionMtt?>> Handle(CreateInstitutionMttCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var InstitutionMtt = new InstitutionMtt
            {
                InstitutionId = request.InstitutionId,
                MttId = request.MttId,
                CommissionType = request.CommissionType,
                CommissionCurrencyId = request.CommissionCurrencyId,
                CommissionPercentage = request.CommissionPercentage,
                CommissionFixed = request.CommissionFixed,
                CompanyId = request.CompanyId,
                Status = (byte) request.Status,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now
            };
            var result = await transactionHandler.ExecuteWithTransactionAsync<InstitutionMtt>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(InstitutionMtt, cancellationToken);
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
