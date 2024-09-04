﻿using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Application.Features.PayerPaymentSpeeds
{
    public class GetPayerPaymentSpeedController : ApiControllerBase
    {
        [Tags("PayerPaymentSpeed")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetPayerPaymentSpeedUrl, Name = Routes.GetPayerPaymentSpeedName)]
        public async Task<ActionResult<ErrorOr<List<PayerPaymentSpeed>>>> Get()
        {
            var result = await Mediator.Send(new GetPayerPaymentSpeedQuery()).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetPayerPaymentSpeedQuery() : IRequest<ErrorOr<List<PayerPaymentSpeed>>>;

        public class GetPayerPaymentSpeedQueryHandler : IRequestHandler<GetPayerPaymentSpeedQuery, ErrorOr<List<PayerPaymentSpeed>>>
        {
            private readonly IPayerPaymentSpeedRepository _repository;

            public GetPayerPaymentSpeedQueryHandler(IPayerPaymentSpeedRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<List<PayerPaymentSpeed>>> Handle(GetPayerPaymentSpeedQuery request, CancellationToken cancellationToken)
            {
                var payerPaymentSpeeds = _repository.ListAsync();

                if (payerPaymentSpeeds == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Payer Payment Speed not found!");
                }
                return payerPaymentSpeeds.Result;
            }
        }
    }
}