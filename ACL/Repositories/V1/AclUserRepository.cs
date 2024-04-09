using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Requests.V1;
using ACL.Response.V1;
using Craftgate.Model;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using SharedLibrary.Models;
using SharedLibrary.Services;
using SharedLibrary.Utilities;
using System.Reflection;
using static ACL.Route.AclRoutesUrl;

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
        public async Task<AclResponse> Add(AclUserRequest request)
        {

            //using (_unitOfWork.BeginTransactionAsync())
            //{
            try
            {
                var aclUser = PrepareInputData(request);
                await _unitOfWork.ApplicationDbContext.AddAsync(aclUser);
                await _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                await _unitOfWork.ApplicationDbContext.Entry(aclUser).ReloadAsync();

                // need to insert user user group
                var UserGroupPrepareData = PrepareDataForUserUserGroups(request, aclUser.Id);
                await _unitOfWork.ApplicationDbContext.AddRangeAsync(UserGroupPrepareData);
                await _unitOfWork.ApplicationDbContext.SaveChangesAsync();

                aclResponse.Data = aclUser;
                aclResponse.Message = Helper.__(messageResponse.createMessage);
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;

                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                //await _unitOfWork.RollbackTransactionAsync();
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            //}
            //await _unitOfWork.CompleteAsync();
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public AclResponse Edit(ulong id, AclUserRequest request)
        {
            try
            {
                var aclUser = _unitOfWork.ApplicationDbContext.AclUsers.Find(id);

                if (aclUser != null)
                {
                    aclUser = PrepareInputData(request, aclUser);
                    _unitOfWork.ApplicationDbContext.Update(aclUser);
                    _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                    _unitOfWork.ApplicationDbContext.Entry(aclUser).ReloadAsync();

                    // first delete all user user group
                    var UserUserGroups = _unitOfWork.ApplicationDbContext.AclUserUsergroups.Where(x => x.UserId == id).ToArray();
                    _unitOfWork.ApplicationDbContext.RemoveRange(UserUserGroups);
                    _unitOfWork.ApplicationDbContext.SaveChangesAsync();

                    // need to insert user user group
                    var UserGroupPrepareData = PrepareDataForUserUserGroups(request, aclUser.Id);
                    _unitOfWork.ApplicationDbContext.AddRangeAsync(UserGroupPrepareData);
                    _unitOfWork.ApplicationDbContext.SaveChangesAsync();

                    aclResponse.Data = aclUser;
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

                // delete all item for user user group
                var UserUserGroups = _unitOfWork.ApplicationDbContext.AclUserUsergroups.Where(x => x.UserId == id).ToArray();
                _unitOfWork.ApplicationDbContext.RemoveRange(UserUserGroups);
                _unitOfWork.ApplicationDbContext.SaveChangesAsync();


                aclResponse.Message = Helper.__(messageResponse.deleteMessage);
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            return aclResponse;
        }

        private AclUser PrepareInputData(AclUserRequest request, AclUser AclUser = null)
        {
            if (AclUser == null)
            {
                return new AclUser
                {
                    FirstName = request.first_name,
                    LastName = request.last_name,
                    Email = request.email,
                    Password = Helper.Bcrypt(request.password),
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
                AclUser.FirstName = request.first_name;
                AclUser.LastName = request.last_name;
                AclUser.Email = request.email;
                AclUser.Password = Helper.Bcrypt(request.password);
                AclUser.Avatar = request.avatar;
                AclUser.Dob = request.dob;
                AclUser.Gender = request.gender;
                AclUser.Address = request.address;
                AclUser.City = request.city;
                AclUser.Country = request.country;
                AclUser.Phone = request.phone;
                AclUser.Username = request.username;
                AclUser.ImgPath = request.img_path;
                AclUser.Status = request.status;
                AclUser.UpdatedAt = DateTime.Now;
                return AclUser;
            }
        }


        public Database.Models.AclUserUsergroup[] PrepareDataForUserUserGroups(AclUserRequest request, ulong user_id)
        {
            IList<Database.Models.AclUserUsergroup> res = new List<Database.Models.AclUserUsergroup>();

            foreach (ulong user_group in request.usergroup)
            {
                Database.Models.AclUserUsergroup aclUserUserGroup = new Database.Models.AclUserUsergroup();
                aclUserUserGroup.UserId = user_id;
                aclUserUserGroup.UsergroupId = user_group;
                aclUserUserGroup.CreatedAt = DateTime.Now;
                aclUserUserGroup.UpdatedAt = DateTime.Now;
                res.Add(aclUserUserGroup);
            }
            return res.ToArray();
        }


    }
}
