﻿using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [Tags("Company")]
    [ApiController]
    public class AclCompanyController : Controller
    {
        /// <inheritdoc/>
        public  required IAclCompanyRepository AclCompanyRepository;
        /// <inheritdoc/>
        public AclCompanyController(IAclCompanyRepository _AclCompanyRepository)
        {
            this.AclCompanyRepository = _AclCompanyRepository;
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyRouteUrl.List, Name = AclRoutesName.AclCompanyRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await this.AclCompanyRepository.GetAll();
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPost(AclRoutesUrl.AclCompanyRouteUrl.Add, Name = AclRoutesName.AclCompanyRouteNames.Add)]
        public Task<AclResponse> Create(AclCompanyCreateRequest request)
        {
            return  this.AclCompanyRepository.AddAclCompany(request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclCompanyRouteUrl.Edit, Name = AclRoutesName.AclCompanyRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclCompanyEditRequest request)
        {
            return  this.AclCompanyRepository.EditAclCompany(id, request);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclCompanyRouteUrl.View, Name = AclRoutesName.AclCompanyRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return this.AclCompanyRepository.FindById(id);
        }
        /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(AclRoutesUrl.AclCompanyRouteUrl.Destroy, Name = AclRoutesName.AclCompanyRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await this.AclCompanyRepository.DeleteCompany(id);
        }
    }
}