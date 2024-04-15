using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Requests.V1;
using ACL.Response.V1;
using Microsoft.EntityFrameworkCore;

namespace ACL.Repositories.V1
{
    public class AclCompanyRepository : GenericRepository<AclCompany>, IAclCompanyRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Company";
        public AclCompanyRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);
        }
        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclCompany = await base.GetById(id);
                aclResponse.Data = aclCompany;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclCompany == null)
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

        public async Task<AclResponse> AddAclCompany(AclCompanyCreateRequest request)
        {
            try
            {
                var aclCompany = PrepareInputData(request);
                Add(aclCompany);
                await _unitOfWork.CompleteAsync();
                await base.ReloadAsync(aclCompany);
                aclResponse.Data = aclCompany;
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
        public async Task<AclResponse> EditAclCompany(ulong Id, AclCompanyEditRequest request)
        {
            try
            {
                var _aclCompany = await base.GetById(Id);
                if (_aclCompany != null)
                {
                    _aclCompany = PrepareInputData(null, request, _aclCompany);
                    await base.UpdateAsync(_aclCompany);
                    await _unitOfWork.CompleteAsync();
                    await base.ReloadAsync(_aclCompany);
                    aclResponse.Data = _aclCompany;
                    aclResponse.Message = messageResponse.editMessage;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    aclResponse.Message = messageResponse.noFoundMessage;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
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

        public async Task<AclResponse> GetAll()
        {
            var aclCompany = await base.All();
            if (aclCompany.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
                aclResponse.Data = aclCompany;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                aclResponse.Message = messageResponse.noFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }

        public async Task<AclResponse> DeleteCompany(ulong id)
        {

            var aclCompany = await base.GetById(id);

            if (aclCompany != null)
            {
                await base.DeleteAsync(aclCompany);
                await _unitOfWork.CompleteAsync();
                aclResponse.Data = aclCompany;
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                aclResponse.Message = messageResponse.noFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }

        public AclCompany PrepareInputData(AclCompanyCreateRequest requ = null, AclCompanyEditRequest req = null, AclCompany _aclCompany = null)
        {
            AclCompany aclCompany = _aclCompany == null ? new AclCompany() : _aclCompany;
            if (requ == null && req != null)
            {
                aclCompany.Name = req.name;
                aclCompany.Cname = req.cname;
                aclCompany.Cemail = req.cemail;
                aclCompany.Address1 = req.address1;
                aclCompany.Address2 = req.address2;
                aclCompany.Postcode = req.postcode;
                aclCompany.Phone = req.phone;
                aclCompany.Fax = req.fax;
                aclCompany.City = req.city;
                aclCompany.State = req.state;
                aclCompany.Country = req.country;
                aclCompany.Logo = req.logo;
                aclCompany.RegistrationNo = req.registration_no;
                aclCompany.Timezone = req.timezone;
                aclCompany.TimezoneValue = req.timezone_value;
                aclCompany.TaxNo = req.tax_no;
                aclCompany.Status = req.status;
            }
            if (requ != null && req == null)
            {
                aclCompany.Name = requ.name;
                aclCompany.Cname = requ.cname;
                aclCompany.Cemail = requ.cemail;
                aclCompany.Address1 = requ.address1;
                aclCompany.Address2 = requ.address2;
                aclCompany.Postcode = requ.postcode;
                aclCompany.Phone = requ.phone;
                aclCompany.Email = requ.email;
                aclCompany.Fax = requ.fax;
                aclCompany.City = requ.city;
                aclCompany.State = requ.state;
                aclCompany.Country = requ.country;
                aclCompany.Logo = requ.logo;
                aclCompany.RegistrationNo = requ.registration_no;
                aclCompany.Timezone = requ.timezone;
                aclCompany.TimezoneValue = requ.timezone_value;
                aclCompany.TaxNo = requ.tax_no;
                aclCompany.UniqueColumnName = requ.unique_column_name;
            }
            aclCompany.UpdatedAt = DateTime.Now;
            if (aclCompany.Id == 0)
            {
                aclCompany.CreatedAt = DateTime.Now;
            }

            return aclCompany;
        }

        private int GetAuthUserId()
        {
            // Implement logic to get the authenticated user's ID
            // For example:
            // return AppAuth.getAuthInfo().user_id;
            return 1;
        }
    }
}
