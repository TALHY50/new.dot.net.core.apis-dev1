
using ACL.Database.Models;
using ACL.Interfaces.Repositories.V1;
using ACL.Interfaces;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Requests;
using Org.BouncyCastle.Asn1.Ocsp;

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
                aclResponse.Message = messageResponse.fetchMessage;
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
                var aclPage = prepareInputData(request);
                _unitOfWork.ApplicationDbContext.Add(aclPage);
                _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                aclResponse.Data = aclPage;
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

        public AclResponse Edit(ulong id, AclPageRequest request)
        {
            try
            {
                var aclPage = prepareInputData(request);
                _unitOfWork.ApplicationDbContext.Update(aclPage);
                _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                _unitOfWork.ApplicationDbContext.Entry(aclPage).Reload();
                aclResponse.Data = aclPage;
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

        public AclResponse findById(ulong id)
        {
            try
            {
                var aclPage = _unitOfWork.ApplicationDbContext.AclPages.Find(id);
                aclResponse.Data = aclPage;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclPage == null)
                {
                    aclResponse.Message = messageResponse.noFoundMessage;
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
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }

            return aclResponse;

        }



        private AclPage prepareInputData(AclPageRequest request)
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
    }
}
