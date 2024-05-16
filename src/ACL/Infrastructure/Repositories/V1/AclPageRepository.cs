using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclPageRepository : IAclPageRepository
    {

        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Page";
        private IAclPageRouteRepository routeRepository;

        private ApplicationDbContext _dbContext;
        public AclPageRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }
        public async Task<AclResponse> GetAll()
        {
            List<AclPage>? aclPage = _dbContext.AclPages.ToList();
            if (aclPage.Any())
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
            }
            this.aclResponse.Data = aclPage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }
        public async Task<AclResponse> AddAclPage(AclPageRequest request)
        {
            try
            {
                AclPage? aclPage = PrepareInputData(request);
                _dbContext.AclPages.AddAsync(aclPage);
                _dbContext.SaveChanges();
                await _dbContext.Entry(aclPage).ReloadAsync();
                this.aclResponse.Data = aclPage;
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }

        public async Task<AclResponse> EditAclPage(ulong id, AclPageRequest request)
        {
            AclPage? aclPage = _dbContext.AclPages.Find(id);
            if (aclPage == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }

            try
            {
                aclPage = PrepareInputData(request, aclPage);
                _dbContext.AclPages.Update(aclPage);
                _dbContext.SaveChanges();
                await _dbContext.Entry(aclPage).ReloadAsync();
                this.aclResponse.Data = aclPage;
                this.aclResponse.Message = this.messageResponse.editMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }

        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                AclPage aclPage = _dbContext.AclPages.Find(id);
                this.aclResponse.Data = aclPage;
                this.aclResponse.Message = this.messageResponse.fetchMessage;
                if (aclPage == null)
                {
                    this.aclResponse.Message = this.messageResponse.notFoundMessage;
                }

                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }
        public async Task<AclResponse> DeleteById(ulong id)
        {
            AclPage? page = _dbContext.AclPages.Find(id);
            if (page != null)
            {
                try
                {
                    _dbContext.AclPages.Remove(page);
                    _dbContext.SaveChanges();
                    await _dbContext.Entry(page).ReloadAsync();
                    await routeRepository.DeleteAll(i => i.PageId == id);
                    this.aclResponse.Message = this.messageResponse.deleteMessage;
                    this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                catch (Exception ex)
                {
                    this.aclResponse.Message = this.messageResponse.somethingIsWrong;
                    this.aclResponse.StatusCode = AppStatusCode.FAIL;
                }

            }
            else
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }

            return this.aclResponse;

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
            this.messageResponse.createMessage = "Page Route Create Successfully";
            try
            {
                AclPageRoute? aclPageRoute = PreparePageRouteInputData(request);
                await routeRepository.AddAsync(aclPageRoute);
                await _dbContext.SaveChangesAsync();
                await routeRepository.ReloadAsync(aclPageRoute);
                this.aclResponse.Data = aclPageRoute;
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }

        public async Task<AclResponse> PageRouteEdit(ulong id, AclPageRouteRequest request)
        {
            this.messageResponse.editMessage = "Page Route Update Successfully";
            try
            {
                AclPageRoute? aclPageRoute = routeRepository.GetById(id).Result;
                if (aclPageRoute != null)
                {
                    AclPageRoute? aclPageRouteUpdateData = PreparePageRouteInputData(request, aclPageRoute);
                    routeRepository.Update(aclPageRouteUpdateData);
                    await _dbContext.SaveChangesAsync();
                    await routeRepository.ReloadAsync(aclPageRouteUpdateData);
                    this.aclResponse.Data = aclPageRouteUpdateData;
                    this.aclResponse.Message = this.messageResponse.editMessage;
                    this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                else
                {
                    this.aclResponse.Message = this.messageResponse.notFoundMessage;
                    this.aclResponse.StatusCode = AppStatusCode.FAIL;
                    return this.aclResponse;
                }
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }

        public async Task<AclResponse> PageRouteDelete(ulong id)
        {
            this.messageResponse.deleteMessage = "Page Route Deleted Successfully";
            AclPageRoute? aclPageRoute = await routeRepository.GetById(id);
            if (aclPageRoute != null)
            {
                await routeRepository.DeleteAsync(aclPageRoute);
                await _dbContext.SaveChangesAsync();
                await routeRepository.ReloadAsync(aclPageRoute);
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            return this.aclResponse;

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


        public void DeletePageRouteByPageId(ulong pageId)
        {
            List<AclPageRoute>? pageRoutes = _dbContext.AclPageRoutes.Where(r => r.PageId == pageId).ToList();
            _dbContext.AclPageRoutes.RemoveRange(pageRoutes);
            _dbContext.SaveChanges();
        }


    }
}
