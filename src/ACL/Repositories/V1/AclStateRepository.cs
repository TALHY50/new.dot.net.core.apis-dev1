﻿using ACL.Core.Models;
using ACL.Interfaces.Repositories.V1;
using ACL.Interfaces;
using ACL.Requests;
using ACL.Response.V1;
using ACL.Utilities;
using SharedLibrary.Services;
using ACL.Database;
using SharedLibrary.Response.CustomStatusCode;
using Microsoft.EntityFrameworkCore;

namespace ACL.Repositories.V1
{
    public class AclStateRepository : GenericRepository<AclState, ApplicationDbContext, ICustomUnitOfWork>, IAclStateRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "State";
        private ICustomUnitOfWork _customUnitOfWork;

        public AclStateRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            _customUnitOfWork = _unitOfWork;
            AppAuth.SetAuthInfo();
            aclResponse = new AclResponse();
            AppAuth.SetAuthInfo();
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> GetAll()
        {
            var aclStates = await _customUnitOfWork.AclStateRepository.Where(s => true)
                .Join(_customUnitOfWork.AclCountryRepository.Where(c => true), s => s.CountryId, c => c.Id, (s, c) => new
                {
                    state = s,
                    country = c

                }).ToListAsync();
            if (aclStates.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclStates;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
        public async Task<AclResponse> Add(AclStateRequest request)
        {

            var aclState = PrepareInputData(request);
            await base.AddAsync(aclState);
            await _unitOfWork.CompleteAsync();
            await _customUnitOfWork.AclStateRepository.ReloadAsync(aclState);
            aclResponse.Data = aclState;
            aclResponse.Message = messageResponse.createMessage;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;

            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;


        }
        public async Task<AclResponse> Edit(ulong id, AclStateRequest request)
        {
            var aclState = await base.GetById(id);
            if (aclState == null)
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                return aclResponse;
            }

            aclState = PrepareInputData(request, aclState);
            await base.UpdateAsync(aclState);
            await _unitOfWork.CompleteAsync();
            await _customUnitOfWork.AclStateRepository.ReloadAsync(aclState);
            aclResponse.Data = aclState;
            aclResponse.Message = messageResponse.editMessage;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;

            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;

        }

        public async Task<AclResponse> FindById(ulong id)
        {

            var aclState = await _customUnitOfWork.AclStateRepository.Where(s => s.Id == id)
                .Join(_customUnitOfWork.AclCountryRepository.Where(c => true), s => s.CountryId, c => c.Id, (s, c) => new
                {
                    state = s,
                    country = c

                }).FirstOrDefaultAsync();
            aclResponse.Data = aclState;
            aclResponse.Message = messageResponse.fetchMessage;
            if (aclState == null)
            {
                aclResponse.Message = messageResponse.notFoundMessage;
            }

            aclResponse.StatusCode = AppStatusCode.SUCCESS;

            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;

        }
        public async Task<AclResponse> DeleteById(ulong id)
        {
            var aclState = await base.GetById(id);

            if (aclState != null)
            {
                await base.DeleteAsync(aclState);
                await _unitOfWork.CompleteAsync();
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return aclResponse;

        }

        private AclState PrepareInputData(AclStateRequest request, AclState aclState = null)
        {
            if (aclState == null)
            {
                aclState = new AclState();
                aclState.CreatedAt = DateTime.Now;
                aclState.CreatedById = AppAuth.GetAuthInfo().UserId;
            }
            aclState.Name = request.Name;
            aclState.CountryId = request.CountryId;
            aclState.Status = request.Status;
            aclState.Description = request.Description;
            aclState.Sequence = request.Sequence;
            aclState.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclState.UpdatedAt = DateTime.Now;

            return aclState;
        }
    }
}
