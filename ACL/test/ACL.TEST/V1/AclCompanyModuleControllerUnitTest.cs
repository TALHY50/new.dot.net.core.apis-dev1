using Notification.Application.Contracts.Requests;
using Notification.Application.Contracts.Response;
using Notification.Application.Infrastructure.Route;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using SharedLibrary.Response.CustomStatusCode;
using static ACL.Application.Infrastructure.Route.AclRoutesUrl;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS0414 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS1998 // Converting null literal or possible null value to non-nullable type.
namespace ACL.Tests.V1
{
    public class AclCompanyModuleControllerUnitTest
    {

        RestClient restClient;
        string token = string.Empty;
        public AclCompanyModuleControllerUnitTest()
        {
            DataCollectors.SetDatabase(false);
            token = DataCollectors.GetAuthorization();
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public async Task Get_All_CompanyModules()
        {
            #region  Arrange

            AclCompanyModuleRequest createReq = GetCompanyModuleRequest();

            #endregion
            #region Act
            var request = new RestRequest(AclRoutesUrl.AclCompanyModuleRouteUrl.List, Method.Get);

            request.AddHeader("Authorization", token);

            var response = restClient.Execute(request);
            #endregion
            #region Assert


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            #endregion Assert

        }
        [Fact]
        public async Task Post_Add_Acl_Company()
        {
            #region  Arrange
            AclCompanyModuleRequest createReq = GetCompanyModuleRequest();

            #endregion
            #region Act
            //// Create request
            var req = new RestRequest(AclRoutesUrl.AclCompanyModuleRouteUrl.Add, Method.Post);
            //Add request body
            req.AddBody(createReq);

            //// Add headers
            req.AddHeader("Authorization", token);

            //// Execute request
            var response = restClient.Execute(req);

            //// Convert actual status code to enum

            #endregion
            #region Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            #endregion Assert
        }
        [Fact]
        public async Task Put_Edit_Acl_CompanyModule()
        {
            #region  Arrange
            AclCompanyModuleRequest editReq = GetCompanyModuleRequest();
            var id = GetRandomID();
            #endregion
            #region Act
            //// Create request
            var request = new RestRequest(AclCompanyModuleRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
            request.AddHeader("Authorization", token);
            //Add request body
            request.AddBody(editReq);

            //// Execute request
            var response = restClient.Execute(request);


            #endregion
            #region Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            #endregion Assert
        }
        [Fact]
        public async Task Get_View_CompanyModule()
        {
            #region  Arrange
            var id = GetRandomID();
            #endregion
            #region Act
            var request = new RestRequest(AclCompanyModuleRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);

            request.AddHeader("Authorization", token);

            var response = restClient.Execute(request);
            #endregion
            #region Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            #endregion Assert

        }

        [Fact]
        public async Task Delete_Acl_Company()
        {
            #region  Arrange
            var id = GetRandomID();
            //// Create RestClient

            #endregion
            #region Act
            //// Create request
            var request = new RestRequest(AclCompanyModuleRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            //Add request body
            request.AddHeader("Authorization", token);

            //// Execute request
            var response = restClient.Execute(request);

            #endregion
            #region Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            #endregion Assert
        }


        public AclCompanyModuleRequest GetCompanyModuleRequest()
        {
            // Generate random data for the company module request
            return new AclCompanyModuleRequest
            {
                CompanyId = DataCollectors.dbContext.AclCompanies.Max(i => i.Id),
                ModuleId = DataCollectors.dbContext.AclModules.Max(i => i.Id)
            };
        }


        private ulong GetRandomID()
        {
            #region Act
            //    // Act
            //return dbContext.AclCompanyModules.Last().Id;
            return (ulong)DataCollectors.dbContext.AclCompanyModules.Max(i => i.Id);
            #endregion
            // }

        }
    }
}

