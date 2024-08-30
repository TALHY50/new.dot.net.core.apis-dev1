using Admin.App.Application.Features.Regions;
using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.TransactionTypes
{
    public class CreateTransactionTypeController : ApiControllerBase
    {
        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateTransactionTypeUrl, Name = Routes.CreateTransactionTypeName)]
        public async Task<ActionResult<ErrorOr<TransactionType>>> Create(CreateTransactionTypeCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record CreateTransactionTypeCommand(
        string? Name,
        byte? Status) : IRequest<ErrorOr<TransactionType>>;

    public class CreateTransactionTypeCommandValidator : AbstractValidator<CreateTransactionTypeCommand>
    {
        public CreateTransactionTypeCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(50)
                .WithMessage("Maximum length can be 50.");
        }
    }


    public class CreateTransactionTypeCommandHandler
        : IRequestHandler<CreateTransactionTypeCommand, ErrorOr<TransactionType>>
    {
        private readonly IImtTransactionTypeRepository _transactionTypeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateTransactionTypeCommandHandler(IHttpContextAccessor httpContextAccessor, IImtTransactionTypeRepository transactionTypeRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _transactionTypeRepository = transactionTypeRepository;
        }

        public async Task<ErrorOr<TransactionType>> Handle(CreateTransactionTypeCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @transactionType = new TransactionType
            {
                Name = request.Name,
                Status = request.Status,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now,
            };

            if (@transactionType == null)
            {
                return Error.NotFound(description: Language.GetMessage(_httpContextAccessor, "Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return _transactionTypeRepository.Add(@transactionType);
        }
    }
}
