﻿
using ACL.Database.Models;
using ACL.Interfaces.Repositories.V1;
using ACL.Interfaces;
using ACL.Requests;
using ACL.Response.V1;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;
using ACL.Services;
using ACL.Utilities;
using Castle.Components.DictionaryAdapter.Xml;

namespace ACL.Repositories.V1
{
    public class AclSubModuleRepository : GenericRepository<AclSubModule, ApplicationDbContext, ICustomUnitOfWork>, IAclSubModuleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Sub Module";
        private ICustomUnitOfWork _customUnitOfWork;

        public AclSubModuleRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            _customUnitOfWork = _unitOfWork;
            AppAuth.SetAuthInfo();
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, _unitOfWork);
        }

        public async Task<AclResponse> GetAll()
        {
            var aclSubModules = await base.All();
            if (aclSubModules.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclSubModules;
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
        public async Task<AclResponse> Add(AclSubModuleRequest request)
        {
            try
            {
                var aclSubModule = PrepareInputData(request);
                await base.AddAsync(aclSubModule);
                await _customUnitOfWork.CompleteAsync();
                await _customUnitOfWork.AclSubModuleRepository.ReloadAsync(aclSubModule);
                aclResponse.Data = aclSubModule;
                aclResponse.Message = messageResponse.createMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;


        }
        public async Task<AclResponse> Edit(ulong id, AclSubModuleRequest request)
        {
            var aclSubModule = await base.GetById(id);
            if (aclSubModule == null)
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                return aclResponse;
            }
            try
            {
                aclSubModule = PrepareInputData(request, aclSubModule);
                await base.UpdateAsync(aclSubModule);
                await _customUnitOfWork.CompleteAsync();
                await _customUnitOfWork.AclSubModuleRepository.ReloadAsync(aclSubModule);
                aclResponse.Data = aclSubModule;
                aclResponse.Message = messageResponse.editMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;

        }

        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclSubModule = await base.GetById(id);
                aclResponse.Data = aclSubModule;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclSubModule == null)
                {
                    aclResponse.Message = messageResponse.notFoundMessage;
                }

                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;

        }
        public async Task<AclResponse> DeleteById(ulong id)
        {
            var subModule = await base.GetById(id);

            if (subModule != null)
            {
                await base.DeleteAsync(subModule);
                await _customUnitOfWork.CompleteAsync();
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }

            return aclResponse;

        }

        private AclSubModule PrepareInputData(AclSubModuleRequest request, AclSubModule aclSubModule = null)
        {
            if (aclSubModule == null)
            {
                aclSubModule = new AclSubModule();
                aclSubModule.Id = request.id;
                aclSubModule.CreatedAt = DateTime.Now;
            }
            aclSubModule.ModuleId = request.module_id;
            aclSubModule.Name = request.name;
            aclSubModule.ControllerName = request.controller_name;
            aclSubModule.DefaultMethod = request.default_method;
            aclSubModule.DisplayName = request.display_name;
            aclSubModule.Icon = request.icon;
            aclSubModule.Sequence = request.sequence;
            aclSubModule.UpdatedAt = DateTime.Now;

            return aclSubModule;
        }
    }
}