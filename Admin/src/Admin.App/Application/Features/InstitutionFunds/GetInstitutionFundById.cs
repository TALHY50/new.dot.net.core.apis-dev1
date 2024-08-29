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

            public GetInstitutionFundByIdQueryHandler(IImtInstitutionFundRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<InstitutionFund>> Handle(GetInstitutionFundByIdQuery request, CancellationToken cancellationToken)
            {
                var institutionFund = _repository.View(request.Id);
                if (institutionFund == null)
                {
                    return Error.NotFound(code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString(), "Institution Fund not found!");
                }

                return institutionFund;
            }
        }
    }
}
