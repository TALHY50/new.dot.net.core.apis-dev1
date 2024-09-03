using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Infrastructure.Attributes;

namespace SharedBusiness.Main.Admin.Application.Features.Countries
{
    public record CreateCountryCommand(
        string? name,
        string? official_state_name,
        string? iso_code,
        string? iso_code_short,
        string? iso_code_num,
        StatusValues status
        ) : IRequest<ErrorOr<Common.Domain.Entities.Country>>;

    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(x => x.iso_code).NotEmpty().IsoCountryCode();
            RuleFor(x => x.iso_code_short).NotEmpty().IsoCountryCodeShort();
            RuleFor(x => x.iso_code_num).NotEmpty().IsoCountryCodeNum();
            RuleFor(x => x.name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.official_state_name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.status).NotEmpty().IsInEnum();
        }
    }

    public class CreateCountryCommandHandler(ILogger<CreateCountryCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, ICountryRepository repository)
        : CountryBase, IRequestHandler<CreateCountryCommand, ErrorOr<Common.Domain.Entities.Country>>
    {
        private readonly ILogger<CreateCountryCommandHandler> _logger = logger;

        public async Task<ErrorOr<Common.Domain.Entities.Country>> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
        {
            var country = new Common.Domain.Entities.Country
            {
                Name = command.name,
                OfficialStateName = command.official_state_name,
                IsoCode = command.iso_code,
                IsoCodeShort = command.iso_code_short,
                IsoCodeNum = command.iso_code_num,
                CreatedById = 0,
                UpdatedById = 0,
                Status = (int) command.status, //1=active, 0=inactive, 2=soft-deleted
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            var result = await transactionHandler.ExecuteWithTransactionAsync<Country>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(country, cancellationToken);
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
