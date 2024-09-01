using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
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
    public class AclRoleUnitTest
    {
        RestClient restClient;
        private string authToken;
        public AclRoleUnitTest()
        {
            DataCollectors.SetDatabase(false);
            authToken = DataCollectors.GetAuthorization("sadmin");
            restClient = new RestClient(DataCollectors.baseUrl);
        }

        [Fact]
        public void TestRoleList()
        {

            //Arrange

            // Act
            var request = new RestRequest(AclRoutesUrl.AclRoleRouteUrl.List, Method.Get);
            request.AddHeader("Authorization", authToken);

            RestResponse response = restClient.Execute(request);

            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }
        [Fact]
        public void AddRoleTest()
        {
            //Arrange
            var data = GetRole();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclRoleRouteUrl.Add, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }
        [Fact]
        public void EditByIdRoleTest()
        {
            //Arrange

            var data = GetRole();
            var id = DataCollectors.dbContext.AclRoles.Max(i => i.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclRoleRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }
        [Fact]
        public void GetByIdRoleTest()
        {
            //Arrange
            var id = DataCollectors.dbContext.AclRoles.Max(i => i.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclRoleRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);
            request.AddHeader("Authorization", authToken);
            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }

        [Fact]
        public void DeleteByIdRoleTest()
        {

            var id = DataCollectors.GetMaxId<Role>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclRoleRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            request.AddHeader("Authorization", authToken);

            RestResponse response = restClient.Execute(request);

            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }

        private AclRoleRequest GetRole()
        {
            var faker = new Faker();
            return new AclRoleRequest
            {
                Name = faker.Random.String2(10, 50),
                Status = (sbyte)faker.Random.Number(1, 2),
                Title = faker.Random.String2(10, 50),

            };

        }

    }
}