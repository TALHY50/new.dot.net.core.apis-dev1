
using ACL.Database.Models;
using ACL.Interfaces.Repositories.V1;
using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using SharedLibrary.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace ACL.Repositories.V1
{
    public class AclPageRepository : GenericRepository<AclPage>, IAclPageRepository
    {

        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Page";
        public AclPageRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);

        }
        public async Task<AclResponse> GetAll()
        {
            var aclPage = await base.All();
            if (aclPage.Any())
            {
                aclResponse.Message = _unitOfWork.LocalizationService.GetLocalizedString("fetchMessage");
            }
            aclResponse.Data = aclPage;
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
        public async Task<AclResponse> Add(AclPageRequest request)
        {
            try
            {
                var aclPage = PrepareInputData(request);
                await _unitOfWork.ApplicationDbContext.AddAsync(aclPage);
                await _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                _unitOfWork.ApplicationDbContext.Entry(aclPage).Reload();
                aclResponse.Data = aclPage;
                aclResponse.Message = Helper.__(messageResponse.createMessage);
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

        public async Task<AclResponse> Edit(ulong id, AclPageRequest request)
        {
            var aclPage = await base.GetById(id);
            if (aclPage == null)
            {
                aclResponse.Message = messageResponse.noFoundMessage;
                return aclResponse;
            }

            try
            {
                aclPage = PrepareInputData(request, aclPage);
                _unitOfWork.ApplicationDbContext.Update(aclPage);
                await _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                await _unitOfWork.ApplicationDbContext.Entry(aclPage).ReloadAsync();
                aclResponse.Data = aclPage;
                aclResponse.Message = Helper.__(messageResponse.editMessage);
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

        public async Task<AclResponse> findById(ulong id)
        {
            try
            {
                var aclPage = _unitOfWork.ApplicationDbContext.AclPages.Find(id);
                aclResponse.Data = aclPage;
                aclResponse.Message = Helper.__(messageResponse.fetchMessage);
                if (aclPage == null)
                {
                    aclResponse.Message = Helper.__(messageResponse.noFoundMessage);
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
        public async Task<AclResponse> deleteById(ulong id)
        {
            var aclPage = _unitOfWork.ApplicationDbContext.AclPages.Find(id);

            if (aclPage != null)
            {
                _unitOfWork.ApplicationDbContext.AclPages.Remove(aclPage);
                _unitOfWork.ApplicationDbContext.SaveChanges();
                aclResponse.Message = Helper.__(messageResponse.deleteMessage);
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
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
            AclPage.ModuleId = request.module_id;
            AclPage.SubModuleId = request.sub_module_id;
            AclPage.Name = request.name;
            AclPage.MethodName = request.method_name;
            AclPage.MethodType = request.method_type;
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
                await _unitOfWork.ApplicationDbContext.AddAsync(aclPageRoute);
                await _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                await _unitOfWork.ApplicationDbContext.Entry(aclPageRoute).ReloadAsync();
                aclResponse.Data = aclPageRoute;
                aclResponse.Message = Helper.__(messageResponse.createMessage);
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

        public async Task<AclResponse> PageRouteEdit(ulong id, AclPageRouteRequest request)
        {
            messageResponse.editMessage = "Page Route Update Successfully";
            try
            {
                var aclPageRoute = _unitOfWork.ApplicationDbContext.AclPageRoutes.Find(id);
                if (aclPageRoute != null)
                {
                    var aclPageRouteUpdateData = PreparePageRouteInputData(request, aclPageRoute);
                    _unitOfWork.ApplicationDbContext.Update(aclPageRouteUpdateData);
                    await _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                    await _unitOfWork.ApplicationDbContext.Entry(aclPageRouteUpdateData).ReloadAsync();
                    aclResponse.Data = aclPageRouteUpdateData;
                    aclResponse.Message = Helper.__(messageResponse.editMessage);
                    aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    aclResponse.Message = Helper.__(messageResponse.noFoundMessage);
                    aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return aclResponse;
                }


            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public async Task<AclResponse> PageRouteDelete(ulong id)
        {
            messageResponse.deleteMessage = "Page Route Deleted Successfully";
            var aclPageRoute = _unitOfWork.ApplicationDbContext.AclPageRoutes.Find(id);
            if (aclPageRoute != null)
            {
                _unitOfWork.ApplicationDbContext.AclPageRoutes.Remove(aclPageRoute);
                await _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                _unitOfWork.ApplicationDbContext.Entry(aclPageRoute).Reload();
                aclResponse.Message = Helper.__(messageResponse.deleteMessage);
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            return aclResponse;

        }

        public AclPageRoute PreparePageRouteInputData(AclPageRouteRequest request, AclPageRoute aclPageRoute = null)
        {
            if (aclPageRoute == null)
            {
                return new AclPageRoute
                {
                    PageId = request.page_id,
                    RouteName = request.route_name,
                    RouteUrl = request.route_url,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
            }
            else
            {
                aclPageRoute.PageId = request.page_id;
                aclPageRoute.RouteName = request.route_name;
                aclPageRoute.RouteUrl = request.route_url;
                aclPageRoute.UpdatedAt = DateTime.Now;
                return aclPageRoute;
            }

        }
    }
}
