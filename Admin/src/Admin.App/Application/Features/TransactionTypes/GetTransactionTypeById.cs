﻿using ACL.App.Contracts.Responses;
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
using static Admin.App.Application.Features.Mtts.InstitutionView;
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
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetTransactionTypeByIdQueryHandler(IHttpContextAccessor httpContextAccessor, IImtTransactionTypeRepository transactionTypeRepository)
            {
                _httpContextAccessor = httpContextAccessor;
                _transactionTypeRepository = transactionTypeRepository;
            }
            public async Task<ErrorOr<TransactionType>> Handle(GetTransactionTypeByIdQuery request, CancellationToken cancellationToken)
            {
                var transactionType = _transactionTypeRepository.View(request.id);
                if (transactionType == null)
                {
                    return Error.NotFound(description: Language.GetMessage(_httpContextAccessor, "Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                
            }
                return transactionType;
            }
        }
    }
