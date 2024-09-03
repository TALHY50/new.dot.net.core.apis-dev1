using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Application.Features.InstitutionFunds
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
            private readonly IInstitutionFundRepository _repository;

            public GetInstitutionFundByIdQueryHandler(IInstitutionFundRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<InstitutionFund>> Handle(GetInstitutionFundByIdQuery request, CancellationToken cancellationToken)
            {
                var institutionFund = await _repository.GetByIdAsync(request.Id);
                if (institutionFund == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Institution Fund not found!");
                }

                return institutionFund;
            }
        }
    }
}
