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
    public class AclPageRepository : GenericRepository<AclPage, ApplicationDbContext, ICustomUnitOfWork>, IAclPageRepository
    {

        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Page";
        private ICustomUnitOfWork _customUnitOfWork;
        public AclPageRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            this._customUnitOfWork = _unitOfWork;
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }
        public async Task<AclResponse> GetAll()
        {
            IEnumerable<AclPage>? aclPage = await base.All();
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
                await base.AddAsync(aclPage);
                await this._unitOfWork.CompleteAsync();
                await this._customUnitOfWork.AclPageRepository.ReloadAsync(aclPage);
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
            AclPage? aclPage = await base.GetById(id);
            if (aclPage == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }

            try
            {
                aclPage = PrepareInputData(request, aclPage);
                base.Update(aclPage);
                await this._unitOfWork.CompleteAsync();
                await this._customUnitOfWork.AclPageRepository.ReloadAsync(aclPage);
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
                AclPage aclPage = await base.GetById(id);
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
            AclPage? page = await base.GetById(id);
            if (page != null)
            {
                var executionStrategy = this._unitOfWork.CreateExecutionStrategy();
                await executionStrategy.ExecuteAsync(async () =>
                {
                    using (var transaction = await this._unitOfWork.BeginTransactionAsync())
                    {
                        try
                        {
                            await base.DeleteAsync(page);
                            this._unitOfWork.Complete();
                            this.DeletePageRouteByPageId(id);
                            this.aclResponse.Message = this.messageResponse.deleteMessage;
                            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                            await transaction.CommitAsync();
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            this._unitOfWork.Logger.LogError(ex, ex.Message);
                            this.aclResponse.Message = this.messageResponse.somethingIsWrong;
                            this.aclResponse.StatusCode = AppStatusCode.FAIL;
                        }
                    }
                });
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
                await this._customUnitOfWork.AclPageRouteRepository.AddAsync(aclPageRoute);
                await this._unitOfWork.CompleteAsync();
                await this._customUnitOfWork.AclPageRouteRepository.ReloadAsync(aclPageRoute);
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
                AclPageRoute? aclPageRoute = this._unitOfWork.ApplicationDbContext.AclPageRoutes.Find(id);
                if (aclPageRoute != null)
                {
                    AclPageRoute? aclPageRouteUpdateData = PreparePageRouteInputData(request, aclPageRoute);
                    this._customUnitOfWork.AclPageRouteRepository.Update(aclPageRouteUpdateData);
                    await this._unitOfWork.CompleteAsync();
                    await this._customUnitOfWork.AclPageRouteRepository.ReloadAsync(aclPageRouteUpdateData);
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
            AclPageRoute? aclPageRoute = await this._customUnitOfWork.AclPageRouteRepository.GetById(id);
            if (aclPageRoute != null)
            {
                await this._customUnitOfWork.AclPageRouteRepository.DeleteAsync(aclPageRoute);
                await this._unitOfWork.ApplicationDbContext.SaveChangesAsync();
                this._unitOfWork.ApplicationDbContext.Entry(aclPageRoute).Reload();
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
            List<AclPageRoute>? pageRoutes = this._customUnitOfWork.ApplicationDbContext.AclPageRoutes.Where(r => r.PageId == pageId).ToList();
            this._customUnitOfWork.ApplicationDbContext.AclPageRoutes.RemoveRange(pageRoutes);
            this._unitOfWork.Complete();
        }


    }
}
