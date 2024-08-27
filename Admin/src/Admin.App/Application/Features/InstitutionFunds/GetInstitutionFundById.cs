using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.InstitutionFunds
{
    public class GetInstitutionFundByIdController : ApiControllerBase
    {
        [Tags("InstitutionFund")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetInstitutionFundByIdUrl, Name = Routes.GetInstitutionFundByIdName)]
        public async Task<ActionResult<ErrorOr<InstitutionFund>>> GetById(uint Id)
        {
            return await Mediator.Send(new GetInstitutionFundByIdQuery(Id)).ConfigureAwait(false);
        }

        public record GetInstitutionFundByIdQuery(uint Id) : IRequest<ErrorOr<InstitutionFund>>;

        internal sealed class GetInstitutionFundByIdValidator : AbstractValidator<GetInstitutionFundByIdQuery>
        {
            public GetInstitutionFundByIdValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
            }
        }

        internal sealed class GetInstitutionFundByIdQueryHandler : IRequestHandler<GetInstitutionFundByIdQuery, ErrorOr<InstitutionFund>>
        {
            private readonly IImtInstitutionFundRepository _repository;

            public GetInstitutionFundByIdQueryHandler(IImtInstitutionFundRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<InstitutionFund>> Handle(GetInstitutionFundByIdQuery request, CancellationToken cancellationToken)
            {
                return _repository.GetByUintId(request.Id);
            }
        }
    }
}
