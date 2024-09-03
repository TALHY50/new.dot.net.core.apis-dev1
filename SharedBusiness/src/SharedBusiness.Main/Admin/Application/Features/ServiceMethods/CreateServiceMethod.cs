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

namespace SharedBusiness.Main.Admin.Application.Features.ServiceMethods
{
    public record CreateServiceMethodCommand(
        byte method,
        uint? company_id,
        StatusValues status
        ) : IRequest<ErrorOr<ServiceMethod>>;

    public class CreateServiceMethodCommandValidator : AbstractValidator<CreateServiceMethodCommand>
    {
        public CreateServiceMethodCommandValidator()
        {
            RuleFor(x => x.method).NotEmpty().MethodRule();
            RuleFor(x => x.company_id).NotEmpty().CompanyIdRule();
            RuleFor(x => x.status).NotEmpty().IsInEnum();
        }
    }

    public class CreateServiceMethodCommandHandler(ILogger<CreateServiceMethodCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, IServiceMethodRepository repository)
        : ServiceMethodBase, IRequestHandler<CreateServiceMethodCommand, ErrorOr<ServiceMethod>>
    {
        private readonly ILogger<CreateServiceMethodCommandHandler> _logger = logger;

        public async Task<ErrorOr<ServiceMethod>> Handle(CreateServiceMethodCommand command, CancellationToken cancellationToken)
        {
            var serviceMethod = new ServiceMethod
            {
                Method = command.method,
                CompanyId = command.company_id,
                Status = (byte)command.status, //1=active, 0=inactive, 2=soft-deleted
                CreatedById = 0,
                UpdatedById = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            var result = await transactionHandler.ExecuteWithTransactionAsync<ServiceMethod>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(serviceMethod, cancellationToken);
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
