﻿using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Application.Features.Countries
{
    /// <inheritdoc/>
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Tags("Country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryService _countryService;
        /// <inheritdoc/>
        public CountryController(ICountryService repository)
        {
            this._countryService = repository;
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCountryRouteUrl.List, Name = AclRoutesName.AclCountryRouteNames.List)]
        public ScopeResponse Index()
        {
            return this._countryService.GetAll();
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclCountryRouteUrl.Add, Name = AclRoutesName.AclCountryRouteNames.Add)]
        public ScopeResponse Create(AclCountryRequest request)
        {
            return this._countryService.Add(request);
        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCountryRouteUrl.View, Name = AclRoutesName.AclCountryRouteNames.View)]
        public ScopeResponse View(uint id)
        {
            return this._countryService.FindById(id);

        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclCountryRouteUrl.Edit, Name = AclRoutesName.AclCountryRouteNames.Edit)]
        public ScopeResponse Edit(uint id, AclCountryRequest request)
        {
            return this._countryService.Edit(id, request);

        }
        /// <inheritdoc/>
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCountryRouteUrl.Destroy, Name = AclRoutesName.AclCountryRouteNames.Destroy)]
        public ScopeResponse Destroy(uint id)
        {
            return this._countryService.DeleteById(id);
        }

    }
}
