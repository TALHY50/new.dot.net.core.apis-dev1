using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclCountryRepository :  IAclCountryRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Country";
        ApplicationDbContext _dbContext;
        public AclCountryRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }

        public AclResponse GetAll()
        {
            var aclRoles = _dbContext.AclCountries.ToList();
            if (aclRoles.Any())
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
            }
            this.aclResponse.Data = aclRoles;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            return this.aclResponse;
        }
        public AclResponse Add(AclCountryRequest request)
        {
            try
            {
                var aclCountry = PrepareInputData(request);
                _dbContext.AclCountries.Add(aclCountry);
                _dbContext.SaveChanges();
               _dbContext.Entry(aclCountry).Reload();
                this.aclResponse.Data = aclCountry;
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.aclResponse;


        }
        public AclResponse Edit(ulong id, AclCountryRequest request)
        {
            var aclCountry = _dbContext.AclCountries.Find(id);
            if (aclCountry == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }
            try
            {
                aclCountry = PrepareInputData(request, aclCountry);
                 _dbContext.AclCountries.Add(aclCountry);
                _dbContext.SaveChanges();
               _dbContext.Entry(aclCountry).Reload();
                this.aclResponse.Data = aclCountry;
                this.aclResponse.Message = this.messageResponse.editMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.aclResponse;

        }
        public AclResponse FindById(ulong id)
        {
            try
            {
                var aclCountry = _dbContext.AclCountries.Find(id);
                this.aclResponse.Data = aclCountry;
                this.aclResponse.Message = this.messageResponse.fetchMessage;
                if (aclCountry == null)
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
            return this.aclResponse;

        }
        public AclResponse DeleteById(ulong id)
        {
            var aclCountry = _dbContext.AclCountries.Find(id);

            if (aclCountry != null)
            {
                _dbContext.AclCountries.Remove(aclCountry);
                 _dbContext.SaveChanges();
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.aclResponse;

        }
        public bool ExistById(ulong id)
        {
            bool exist = false;
            var aclCountry = _dbContext.AclCountries.Find(id);
            if(aclCountry!= null)
            {
                exist = true;
            }
            return exist;
        }
        private AclCountry PrepareInputData(AclCountryRequest request, AclCountry aclCountry = null)
        {
            if (aclCountry == null)
            {
                aclCountry = new AclCountry();
                aclCountry.CreatedById = AppAuth.GetAuthInfo().UserId;
                aclCountry.CreatedAt = DateTime.Now;
            }
            aclCountry.Name = request.Name;
            aclCountry.Description = request.Description;
            aclCountry.Code = request.Code;
            aclCountry.Status = request.Status;
            aclCountry.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclCountry.UpdatedAt = DateTime.Now;

            return aclCountry;
        }


    }
}
