﻿using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;

namespace ACL.Business.Domain.Services
{
    public interface IStateService : IStateRepository
    {
        /// <inheritdoc/>
        ScopeResponse GetAll();
        /// <inheritdoc/>
        ScopeResponse Add(AclStateRequest stateRequest);
        /// <inheritdoc/>
        ScopeResponse Edit(uint id, AclStateRequest stateRequest);
        /// <inheritdoc/>
        ScopeResponse FindById(uint id);
        /// <inheritdoc/>
        ScopeResponse DeleteById(uint id);
    }
}
