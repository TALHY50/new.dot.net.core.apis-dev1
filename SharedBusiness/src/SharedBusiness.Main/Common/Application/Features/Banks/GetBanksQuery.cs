using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Common.Application.Features.Banks
{
    public record GetBanksQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<Bank>>>;
    public class GetBanksQueryValidator : AbstractValidator<GetBanksQuery>
    {
        public GetBanksQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .When(x => x.PageNumber != 0)
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .When(x => x.PageNumber > 0)
                .When(x => x.PageSize != 0)
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class GetBanksQueryHandler
        : BankBaseCommand, IRequestHandler<GetBanksQuery, ErrorOr<List<Bank>>>
    {
        private readonly IBankRepository _repository;

        public GetBanksQueryHandler(IBankRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Bank>>> Handle(GetBanksQuery request, CancellationToken cancellationToken)
        {
            List<Bank>? banks;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                banks = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                banks = await _repository.ListAsync(cancellationToken);

            }

            if (banks == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return banks;
        }
    }
}
