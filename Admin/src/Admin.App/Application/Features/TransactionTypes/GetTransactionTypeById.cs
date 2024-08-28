﻿using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;
using static Admin.App.Application.Features.Mtts.MttView;
using static Admin.App.Application.Features.TransactionTypes.GetTransactionTypeController;

namespace Admin.App.Application.Features.TransactionTypes
{
    public class GetTransactionTypeByIdController : ApiControllerBase
    {
        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetTransactionTypeByIdUrl, Name = Routes.GetTransactionTypeByIdName)]
        public async Task<ActionResult<ErrorOr<TransactionType>>> Get(uint id)
        {
            var result = await Mediator.Send(new GetTransactionTypeByIdQuery(id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

        public record GetTransactionTypeByIdQuery(uint id) : IRequest<ErrorOr<TransactionType>>;

        public class GetTransactionTypeByIdQueryValidator : AbstractValidator<GetTransactionTypeByIdQuery>
        {
            public GetTransactionTypeByIdQueryValidator()
            {
                RuleFor(x => x.id)
                    .NotEmpty()
                    .WithMessage("ID is required");
            }
        }

        public class GetTransactionTypeByIdQueryHandler
            : IRequestHandler<GetTransactionTypeByIdQuery, ErrorOr<TransactionType>>
        {
            private readonly IImtTransactionTypeRepository _transactionTypeRepository;

            public GetTransactionTypeByIdQueryHandler(IImtTransactionTypeRepository transactionTypeRepository)
            {
                _transactionTypeRepository = transactionTypeRepository;
            }
            public async Task<ErrorOr<TransactionType>> Handle(GetTransactionTypeByIdQuery request, CancellationToken cancellationToken)
            {
                var transactionType = _transactionTypeRepository.GetByUintId(request.id);
                if (transactionType == null)
                {
                    return Error.NotFound(description: "TransactionType not found", code: AppStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
                else
                {
                    return transactionType;
                }
            }
        }
    }
