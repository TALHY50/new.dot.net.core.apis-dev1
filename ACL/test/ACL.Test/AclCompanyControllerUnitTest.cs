using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Web.Presentation.Routes;
using Bogus;
using Newtonsoft.Json;
using RestSharp;
using SharedKernel.Main.Contracts.Common;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS0414 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS1998 // Converting null literal or possible null value to non-nullable type.
namespace ACL.TEST
{
    public class AclCompanyControllerUnitTest
    {
        RestClient restClient;
        public AclCompanyControllerUnitTest()
        {
            DataCollectors.SetDatabase(false);
            restClient = new RestClient(DataCollectors.baseUrl);
        }

        [Fact]
        public async Task Get_All_Companies()
        {
            #region  Arrange
            //var chk = await GetRandomID();

            #endregion
            #region Act
            var request = new RestRequest(AclRoutesUrl.AclCompanyRouteUrl.List, Method.Get);

            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);

            var response = restClient.Execute(request);
            #endregion
            #region Assert

            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            #endregion Assert

        }

        [Fact]
        public async Task Post_Add_Acl_Company()
        {
            #region Arrange
            AclCompanyCreateRequest createReq = GetCompanyCreateRequest();
            #endregion

            #region Act
            //// CreateCompanyModule request
            var request = new RestRequest(AclRoutesUrl.AclCompanyRouteUrl.Add, Method.Post);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            //// Serialize the request body
            request.AddJsonBody(createReq);

            //// Execute request
            var response = restClient.Execute(request);

            //// Convert actual status code to enum
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            #endregion

            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);
            #endregion Assert
        }
        [Fact]
        public async Task Put_Edit_Acl_Company()
        {
            #region  Arrange
            AclCompanyEditRequest editReq = GetCompanyEditRequest();
            var id = GetRandomID();
            #endregion
            #region Act
            //// CreateCompanyModule request
            var request = new RestRequest(AclRoutesUrl.AclCompanyRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);

            //Add request body
            request.AddJsonBody(editReq);

            //// Add headers
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);

            //// Execute request
            var response = restClient.Execute(request);

            //// Assert for create

            #endregion
            #region Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            #endregion Assert
        }
        [Fact]

        public async Task Get_View_Company()
        {
            #region  Arrange
            var id = GetRandomID();
            #endregion

            #region Act
            var request = new RestRequest($"{AclRoutesUrl.AclCompanyRouteUrl.View.Replace("{id}", id.ToString())}", Method.Get);

            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);

            var response = restClient.Execute(request);
            #endregion

            #region Assert
            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            #endregion Assert
        }
        [Fact]

        public async Task Delete_Acl_Company()
        {
            #region  Arrange
            var id = GetRandomID();

            #endregion
            #region Act
            //// CreateCompanyModule request
            var request = new RestRequest(AclRoutesUrl.AclCompanyRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            //Add request body

            //// Add headers
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);

            //// Execute request
            var response = restClient.Execute(request);

            //// Convert actual status code to enum
            int actualEditStatusCode = (int)response.StatusCode;
            //// Assert for create

            #endregion
            #region Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);
            #endregion Assert
        }

        public AclCompanyCreateRequest GetCompanyCreateRequest()
        {
            var faker = new Faker();

            // Generate random data for the company creation request
            return new AclCompanyCreateRequest
            {
                Name = faker.Company.CompanyName(),
                Cname = faker.Company.CompanyName(),
                Cemail = faker.Internet.Email(),
                Address1 = faker.Address.StreetAddress(),
                Address2 = faker.Address.SecondaryAddress(),
                City = faker.Random.String2(15),
                State = faker.Address.State(),
                Country = faker.Address.Country(),
                PostCode = faker.Address.ZipCode(),
                Phone = faker.Random.String2(15),
                Timezone = faker.Random.Number(-12, 12), // Convert to string if 'timezone' is a string
                TimeZoneValue = faker.Random.String2(20),
                Logo = faker.Image.PicsumUrl(),
                Fax = faker.Random.String2(15),
                RegistrationNo = faker.Random.AlphaNumeric(10),
                TaxNo = faker.Random.AlphaNumeric(10),
                UniqueColumnName = (sbyte)faker.Random.Byte(), // Ensure 'unique_column_name' is of correct type
                Email = faker.Internet.Email(),
                Password = faker.Internet.Password()
            };
        }

        private AclCompanyEditRequest GetCompanyEditRequest()
        {
            var faker = new Faker();
            return new AclCompanyEditRequest
            {
                Name = faker.Company.CompanyName(),
                Cname = faker.Company.CompanyName(),
                Cemail = faker.Internet.Email(),
                Address1 = faker.Address.StreetAddress(),
                Address2 = faker.Address.SecondaryAddress(),
                City = faker.Random.String2(15),
                State = faker.Address.State(),
                Country = faker.Address.Country(),
                PostCode = faker.Address.ZipCode(),
                Phone = faker.Random.String2(15),
                Timezone = faker.Random.Number(0, 24),
                UniqueColumnName = faker.Random.Number(1, 100),
                TimezoneValue = faker.Random.String2(20),
                Logo = faker.Image.PicsumUrl(),
                Fax = faker.Random.String2(15),
                RegistrationNo = faker.Random.AlphaNumeric(10),
                TaxNo = faker.Random.AlphaNumeric(10),
                Status = (sbyte)faker.Random.Number(0, 1) // Example for status
            };

        }

        private ulong GetRandomID()
        {
            //#region Arrange
            //AclCompanyCreateRequest createReq = GetCompanyCreateRequest();



            //#endregion
            //#region Act

            return (ulong)DataCollectors.dbContext.AclCompanies.Where(t => t.Status == 1).Max(t => t.Id);

            //// Act
            //var ScopeResponse = await controller.CreateCompanyModule(createReq);
            ////var aclData = unitOfWork.CompanyRepository.Add((Company)ScopeResponse.Data);
            //// Commit the changes to the database
            //await unitOfWork.CompleteAsync();
            //var data = ScopeResponse.Data as Company;

            //return data.Id;
            //#endregion
        }

    }
}

