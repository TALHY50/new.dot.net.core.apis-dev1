using Admin.App.Application.Features.Regions;
using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;

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
        private readonly ITransactionTypeRepository _transactionTypeRepository;

        public CreateTransactionTypeCommandHandler(ITransactionTypeRepository transactionTypeRepository)
        {
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

            return _transactionTypeRepository.Add(@transactionType);
        }
    }
}
