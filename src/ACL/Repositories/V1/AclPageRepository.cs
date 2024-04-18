
using ACL.Database.Models;
using ACL.Interfaces.Repositories.V1;
using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using SharedLibrary.Utilities;

namespace ACL.Repositories.V1
{
    public class AclPageRepository : IAclPageRepository
    {

        private readonly IUnitOfWork _unitOfWork;
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Page";

        public AclPageRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);
        }
        public AclResponse GetAll()
        {
            var aclPage = _unitOfWork.ApplicationDbContext.AclPages.ToList();
            if (aclPage.Count > 0)
            {
                aclResponse.Message = Helper.__(messageResponse.fetchMessage);
            }
            aclResponse.Data = aclPage;
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
        public AclResponse Add(AclPageRequest request)
        {
            try
            {
                var aclPage = PrepareInputData(request);
                _unitOfWork.ApplicationDbContext.AddAsync(aclPage);
                _unitOfWork.ApplicationDbContext.SaveChangesAsync();
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

        public AclResponse Edit(ulong id, AclPageRequest request)
        {
            try
            {
                var aclPage = PrepareInputData(request);
                _unitOfWork.ApplicationDbContext.Update(aclPage);
                _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                _unitOfWork.ApplicationDbContext.Entry(aclPage).ReloadAsync();
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

        public AclResponse findById(ulong id)
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
        public AclResponse deleteById(ulong id)
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



        private AclPage PrepareInputData(AclPageRequest request)
        {
            return new AclPage
            {
                Id = request.id,
                ModuleId = request.module_id,
                SubModuleId = request.sub_module_id,
                Name = request.name,
                MethodName = request.method_name,
                MethodType = request.method_type,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

        }


        public AclResponse PageRouteCreate(AclPageRouteRequest request)
        {
            messageResponse.createMessage = "Page Route Create Successfully";
            try
            {
                var aclPageRoute = PreparePageRouteInputData(request);
                _unitOfWork.ApplicationDbContext.AddAsync(aclPageRoute);
                _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                _unitOfWork.ApplicationDbContext.Entry(aclPageRoute).ReloadAsync();
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

        public AclResponse PageRouteEdit(ulong id, AclPageRouteRequest request)
        {
            messageResponse.editMessage = "Page Route Update Successfully";
            try
            {
                var aclPageRoute = _unitOfWork.ApplicationDbContext.AclPageRoutes.Find(id);
                if (aclPageRoute != null)
                {
                    var aclPageRouteUpdateData = PreparePageRouteInputData(request, aclPageRoute);
                    _unitOfWork.ApplicationDbContext.Update(aclPageRouteUpdateData);
                    _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                    _unitOfWork.ApplicationDbContext.Entry(aclPageRouteUpdateData).ReloadAsync();
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

        public AclResponse PageRouteDelete(ulong id)
        {
            messageResponse.deleteMessage = "Page Route Deleted Successfully";
            var aclPageRoute = _unitOfWork.ApplicationDbContext.AclPageRoutes.Find(id);
            if (aclPageRoute != null)
            {
                _unitOfWork.ApplicationDbContext.AclPageRoutes.Remove(aclPageRoute);
                _unitOfWork.ApplicationDbContext.SaveChanges();
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
