using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;

namespace ADMIN.App.Application.Features.PayerPaymentSpeeds
{
    public class GetPayerPaymentSpeedByIdController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetPayerPaymentSpeedByIdUrl, Name = Routes.GetPayerPaymentSpeedByIdName)]
        public async Task<ActionResult<ErrorOr<PayerPaymentSpeed>>> GetById(int Id)
        {
            return await Mediator.Send(new GetPayerPaymentSpeedByIdQuery(Id)).ConfigureAwait(false);
        }

        public record GetPayerPaymentSpeedByIdQuery(int Id) : IRequest<ErrorOr<PayerPaymentSpeed>>;

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
            public Task<ErrorOr<PayerPaymentSpeed>> Handle(GetPayerPaymentSpeedByIdQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
