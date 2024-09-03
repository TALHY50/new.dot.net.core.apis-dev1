using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.PayerPaymentSpeeds;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Application.Features.PayerPaymentSpeeds
{
    public class UpdatePayerPaymentSpeedController : ApiControllerBase
    {
        [Tags("PayerPaymentSpeed")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdatePayerPaymentSpeedUrl, Name = Routes.UpdatePayerPaymentSpeedName)]

        public async Task<ActionResult<ErrorOr<PayerPaymentSpeed>>> Update(uint Id, UpdatePayerPaymentSpeedCommand command)
        {
            var commandWithId = command with { id = Id };
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
}
