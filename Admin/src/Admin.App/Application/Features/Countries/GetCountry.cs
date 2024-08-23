﻿using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Domain.Notification.Notifications.Events;

namespace Admin.App.Application.Features.Countries
{
    public class GetCountryController : ApiControllerBase
    {
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetCountryUrl, Name = Routes.GetCountryName)]
        public async Task<ActionResult<ErrorOr<Country>>> Get()
        {
            return await Mediator.Send(new GetCountryQuery()).ConfigureAwait(false);
        }

        public record GetCountryQuery() : IQuery<ErrorOr<Country>>;

        internal sealed class GetCountryQueryHandler() : IQueryHandler<GetCountryQuery, ErrorOr<Country>>
        {
            // get all data 
            public Task<ErrorOr<Country>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}