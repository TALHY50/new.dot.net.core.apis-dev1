
using ACL.Database.Models;
using ACL.Interfaces.Repositories.V1;
using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using SharedLibrary.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using SharedLibrary.Services;
using ACL.Database;
using SharedLibrary.Interfaces;
using ACL.Services;
using ACL.Utilities;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Repositories.V1
{
    public class AclPageRepository : GenericRepository<AclPage, ApplicationDbContext, ICustomUnitOfWork>, IAclPageRepository
    {

        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Page";
        private ICustomUnitOfWork _customUnitOfWork;
        public AclPageRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            _customUnitOfWork = _unitOfWork;
            aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }
        public async Task<AclResponse> GetAll()
        {
            var aclPage = await base.All();
            if (aclPage.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclPage;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
        public async Task<AclResponse> AddAclPage(AclPageRequest request)
        {
            try
            {
                var aclPage = PrepareInputData(request);
                await base.AddAsync(aclPage);
                await _unitOfWork.CompleteAsync();
                await _customUnitOfWork.AclPageRepository.ReloadAsync(aclPage);
                aclResponse.Data = aclPage;
                aclResponse.Message = messageResponse.createMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public async Task<AclResponse> EditAclPage(ulong id, AclPageRequest request)
        {
            var aclPage = await base.GetById(id);
            if (aclPage == null)
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                return aclResponse;
            }

            try
            {
                aclPage = PrepareInputData(request, aclPage);
                base.Update(aclPage);
                await _unitOfWork.CompleteAsync();
                await _customUnitOfWork.AclPageRepository.ReloadAsync(aclPage);
                aclResponse.Data = aclPage;
                aclResponse.Message = messageResponse.editMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                AclPage aclPage = await base.GetById(id);
                aclResponse.Data = aclPage;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclPage == null)
                {
                    aclResponse.Message = messageResponse.notFoundMessage;
                }

                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;

        }
        public async Task<AclResponse> DeleteById(ulong id)
        {

            if (await base.GetById(id) != null)
            {
                await base.DeleteAsync(await base.GetById(id));
                _unitOfWork.Complete();
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return aclResponse;

        }



        private AclPage PrepareInputData(AclPageRequest request, AclPage AclPage = null)
        {
            if (AclPage == null)
            {
                AclPage = new AclPage();
                AclPage.CreatedAt = DateTime.Now;
            }
            AclPage.ModuleId = request.ModuleId;
            AclPage.SubModuleId = request.SubModuleId;
            AclPage.Name = request.Name;
            AclPage.MethodName = request.MethodName;
            AclPage.MethodType = request.MethodType;
            AclPage.CreatedAt = DateTime.Now;
            AclPage.UpdatedAt = DateTime.Now;
            return AclPage;
        }


        public async Task<AclResponse> PageRouteCreate(AclPageRouteRequest request)
        {
            messageResponse.createMessage = "Page Route Create Successfully";
            try
            {
                var aclPageRoute = PreparePageRouteInputData(request);
                await _customUnitOfWork.AclPageRouteRepository.AddAsync(aclPageRoute);
                await _unitOfWork.CompleteAsync();
                await _customUnitOfWork.AclPageRouteRepository.ReloadAsync(aclPageRoute);
                aclResponse.Data = aclPageRoute;
                aclResponse.Message = messageResponse.createMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public async Task<AclResponse> PageRouteEdit(ulong id, AclPageRouteRequest request)
        {
            messageResponse.editMessage = "Page Route Update Successfully";
            try
            {
                var aclPageRoute = _unitOfWork.ApplicationDbContext.AclPageRoutes.Find(id);
                if (aclPageRoute != null)
                {
                    var aclPageRouteUpdateData = PreparePageRouteInputData(request, aclPageRoute);
                    _customUnitOfWork.AclPageRouteRepository.Update(aclPageRouteUpdateData);
                    await _unitOfWork.CompleteAsync();
                    await _customUnitOfWork.AclPageRouteRepository.ReloadAsync(aclPageRouteUpdateData);
                    aclResponse.Data = aclPageRouteUpdateData;
                    aclResponse.Message = messageResponse.editMessage;
                    aclResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                else
                {
                    aclResponse.Message = messageResponse.notFoundMessage;
                    aclResponse.StatusCode = AppStatusCode.FAIL;
                    return aclResponse;
                }


            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public async Task<AclResponse> PageRouteDelete(ulong id)
        {
            messageResponse.deleteMessage = "Page Route Deleted Successfully";
            AclPageRoute? aclPageRoute = await _customUnitOfWork.AclPageRouteRepository.GetById(id);
            if (aclPageRoute != null)
            {
                await _customUnitOfWork.AclPageRouteRepository.DeleteAsync(aclPageRoute);
                await _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                _unitOfWork.ApplicationDbContext.Entry(aclPageRoute).Reload();
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            return aclResponse;

        }

        public AclPageRoute PreparePageRouteInputData(AclPageRouteRequest request, AclPageRoute aclPageRoute = null)
        {
            if (aclPageRoute == null)
            {
                return new AclPageRoute
                {
                    PageId = request.PageId,
                    RouteName = request.RouteName,
                    RouteUrl = request.RouteUrl,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
            }
            else
            {
                aclPageRoute.PageId = request.PageId;
                aclPageRoute.RouteName = request.RouteName;
                aclPageRoute.RouteUrl = request.RouteUrl;
                aclPageRoute.UpdatedAt = DateTime.Now;
                return aclPageRoute;
            }

        }
    }
}
