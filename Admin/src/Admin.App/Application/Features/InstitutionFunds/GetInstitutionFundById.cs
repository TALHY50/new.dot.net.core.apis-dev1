﻿using ACL.App.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.InstitutionFunds
{
    public class GetInstitutionFundByIdController : ApiControllerBase
    {
        [Tags("InstitutionFund")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetInstitutionFundByIdUrl, Name = Routes.GetInstitutionFundByIdName)]
        public async Task<ActionResult<ErrorOr<InstitutionFund>>> GetById(uint Id)
        {
            var result = await Mediator.Send(new GetInstitutionFundByIdQuery(Id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetInstitutionFundByIdQuery(uint Id) : IRequest<ErrorOr<InstitutionFund>>;

        public class GetInstitutionFundByIdValidator : AbstractValidator<GetInstitutionFundByIdQuery>
        {
            public GetInstitutionFundByIdValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
            }
        }

        public class GetInstitutionFundByIdQueryHandler : IRequestHandler<GetInstitutionFundByIdQuery, ErrorOr<InstitutionFund>>
        {
            private readonly IImtInstitutionFundRepository _repository;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetInstitutionFundByIdQueryHandler(IHttpContextAccessor httpContextAccessor, IImtInstitutionFundRepository repository)
            {
                _httpContextAccessor = httpContextAccessor;
                _repository = repository;
            }
            public async Task<ErrorOr<InstitutionFund>> Handle(GetInstitutionFundByIdQuery request, CancellationToken cancellationToken)
            {
                var institutionFund = _repository.View(request.Id);
                var message = new MessageResponse("Record not found");
                if (institutionFund == null)
                {
                    return Error.NotFound(description: Language.GetMessage(_httpContextAccessor, "Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return institutionFund;
            }
        }
    }
}
