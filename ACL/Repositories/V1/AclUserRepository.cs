using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests.V1;
using ACL.Response.V1;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using SharedLibrary.Services;
using SharedLibrary.Utilities;

namespace ACL.Repositories.V1
{
    public class AclUserRepository : IAclUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User";

        public AclUserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);
        }
        public AclResponse GetAll()
        {
            var aclUser = _unitOfWork.ApplicationDbContext.AclUsers.ToList();
            if (aclUser.Count > 0)
            {
                aclResponse.Message = Helper.__(messageResponse.fetchMessage);
            }
            aclResponse.Data = aclUser;
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
        public AclResponse Add(AclUserRequest request)
        {
            try
            {
                var aclUser = PrepareInputData(request);
                _unitOfWork.ApplicationDbContext.AddAsync(aclUser);
                _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                _unitOfWork.ApplicationDbContext.Entry(aclUser).Reload();
                var user_id= aclUser.Id;
                // need to insert user user group


                aclResponse.Data = aclUser;
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

        public AclResponse Edit(ulong id, AclUserRequest request)
        {
            try
            {
                var aclUser = PrepareInputData(request);
                _unitOfWork.ApplicationDbContext.Update(aclUser);
                _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                _unitOfWork.ApplicationDbContext.Entry(aclUser).ReloadAsync();
                aclResponse.Data = aclUser;
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
                var aclUser = _unitOfWork.ApplicationDbContext.AclUsers.Find(id);
                aclResponse.Data = aclUser;
                aclResponse.Message = Helper.__(messageResponse.fetchMessage);
                if (aclUser == null)
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
            var aclUser = _unitOfWork.ApplicationDbContext.AclUsers.Find(id);

            if (aclUser != null)
            {
                _unitOfWork.ApplicationDbContext.AclUsers.Remove(aclUser);
                _unitOfWork.ApplicationDbContext.SaveChanges();
                aclResponse.Message = Helper.__(messageResponse.deleteMessage);
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }

            return aclResponse;

        }

        private AclUser PrepareInputData(AclUserRequest request, AclUser AclUser = null)
        {
            if (request == null)
            {
                return new AclUser
                {
                    FirstName = request.first_name,
                    LastName = request.last_name,
                    Email = request.email,
                    Password = Cryptographer.AppEncrypt( request.password),
                    Avatar = request.avatar,
                    Dob = request.dob,
                    Gender = request.gender,
                    Address = request.address,
                    City = request.city,
                    Country = request.country,
                    Phone = request.phone,
                    Username = request.username,
                    ImgPath = request.img_path,
                    Status = request.status,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
            }
            else
            {
                AclUser.CreatedAt = DateTime.Now;
                AclUser.UpdatedAt = DateTime.Now;
                return AclUser;
            }
        }

    }
}
