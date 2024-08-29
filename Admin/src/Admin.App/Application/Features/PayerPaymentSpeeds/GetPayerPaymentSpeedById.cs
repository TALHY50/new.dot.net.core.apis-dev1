using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace ADMIN.App.Application.Features.PayerPaymentSpeeds
{
    public class GetPayerPaymentSpeedByIdController : ApiControllerBase
    {
        [Tags("PayerPaymentSpeed")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetPayerPaymentSpeedByIdUrl, Name = Routes.GetPayerPaymentSpeedByIdName)]
        public async Task<ActionResult<ErrorOr<PayerPaymentSpeed>>> GetById(uint Id)
        {
            return await Mediator.Send(new GetPayerPaymentSpeedByIdQuery(Id)).ConfigureAwait(false);
        }

        public record GetPayerPaymentSpeedByIdQuery(uint Id) : IRequest<ErrorOr<PayerPaymentSpeed>>;

        internal sealed class GetPayerPaymentSpeedByIdValidator : AbstractValidator<GetPayerPaymentSpeedByIdQuery>
        {
            public GetPayerPaymentSpeedByIdValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
            }
        }

        internal sealed class GetPayerPaymentSpeedByIdQueryHandler : IRequestHandler<GetPayerPaymentSpeedByIdQuery, ErrorOr<PayerPaymentSpeed>>
        {
            private readonly IImtPayerPaymentSpeedRepository _repository;

            public GetPayerPaymentSpeedByIdQueryHandler(IImtPayerPaymentSpeedRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<PayerPaymentSpeed>> Handle(GetPayerPaymentSpeedByIdQuery request, CancellationToken cancellationToken)
            {
                return _repository.GetByUintId(request.Id);
            }
        }
    }
}
