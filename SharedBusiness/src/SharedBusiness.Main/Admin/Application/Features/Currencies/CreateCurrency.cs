using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Common.Application.Features.Currencies;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;


namespace SharedBusiness.Main.Admin.Application.Features.Currencies
{
    public record CreateCurrencyCommand(
        string? Code,
        string? IsoCode,
        string? Name,
        string? Symbol,
        StatusValues Status
        ) : IRequest<ErrorOr<Currency>>;

    public class CreateCurrencyCommandValidator : AbstractValidator<CreateCurrencyCommand>
    {
        public CreateCurrencyCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty().MinimumLength(1).MaximumLength(10).WithMessage("IsoCodeShort cannot be empty");
            RuleFor(x => x.IsoCode).NotEmpty().MinimumLength(1).MaximumLength(10).WithMessage("iso_code cannot be empty");
            RuleFor(x => x.Name).NotEmpty().MinimumLength(1).MaximumLength(100).WithMessage("name cannot be empty");
            RuleFor(x => x.Symbol).NotEmpty().MinimumLength(1).MaximumLength(50).WithMessage("Symbol cannot be empty");
        }
    }

    public class CreateCurrencyCommandHandler(ILogger<CreateCurrencyCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, ICurrencyRepository repository)
        : CurrencyBase, IRequestHandler<CreateCurrencyCommand, ErrorOr<Currency>>
    {
        private readonly ILogger<CreateCurrencyCommandHandler> _logger = logger;

        public async Task<ErrorOr<Currency>> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var Currency = new Common.Domain.Entities.Currency
            {
                Code = request.Code,
                IsoCode = request.IsoCode,
                Name = request.Name,
                Symbol = request.Symbol,
                CreatedById = 1,
                UpdatedById = 2,
                Status = (byte) request.Status,
                CreatedAt = now,
                UpdatedAt = now
            };
            var result = await transactionHandler.ExecuteWithTransactionAsync<Currency>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(Currency, cancellationToken);
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
