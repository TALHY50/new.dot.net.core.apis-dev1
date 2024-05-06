using ACL.Requests;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
using ACL.Route;
using ACL.Database.Models;
using ACL.Services;

namespace ACL.Tests.V1
{
    public class AclRoleUnitTest
    {
        RestClient restClient;
        private string authToken;
        public AclRoleUnitTest()
        {
            DataCollectors.SetDatabase(false);
            authToken = DataCollectors.GetAuthorization();
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
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

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
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        [Fact]
        public void GetByIdRoleTest()
        {
            //Arrange
            var id = DataCollectors.unitOfWork.ApplicationDbContext.AclRoles.Max(i => i.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclRoleRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);
            request.AddHeader("Authorization", authToken);
            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void EditByIdRoleTest()
        {
            //Arrange

            var data = GetRole();
            var id = DataCollectors.unitOfWork.ApplicationDbContext.AclRoles.Max(i => i.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclRoleRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void DeleteByIdRoleTest()
        {

            var id = DataCollectors.GetMaxId<AclRole>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclRoleRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            request.AddHeader("Authorization", authToken);

            RestResponse response = restClient.Execute(request);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

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