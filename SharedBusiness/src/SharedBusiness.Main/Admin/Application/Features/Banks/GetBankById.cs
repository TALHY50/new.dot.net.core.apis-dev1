using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.Banks;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Admin.Application.Features.Banks
{
    public record GetBankByIdQuery(uint id) : IRequest<ErrorOr<Bank>>;
    public class GetBankByIdQueryValidator : AbstractValidator<GetBankByIdQuery>
    {
        public GetBankByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Bank ID is required");
        }
    }

    public class GetBankByIdQueryHandler : BankBase, IRequestHandler<GetBankByIdQuery, ErrorOr<Bank>>
    {
        private readonly IBankRepository _repository;

        public GetBankByIdQueryHandler(IBankRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Bank>> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
        {
            var bank = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (bank == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return bank;
        }
    }
}
