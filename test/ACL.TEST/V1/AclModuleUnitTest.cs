using ACL.Requests;
using ACL.Services;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
using ACL.Database.Models;
using ACL.Requests.V1;

namespace ACL.Tests.V1
{
    public class AclModuleUnitTest
    {
        RestClient restClient;
        public AclModuleUnitTest()
        {
             DataCollectors.SetDatabase(false);
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public void TestModuleList()
        {

            //Arrange

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclModuleRouteUrl.List, Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void AddModuleTest()
        {
            //Arrange
            var data = GetModule();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclModuleRouteUrl.Add, Method.Post);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        [Fact]
        public void GetByIdModuleTest()
        {
            //Arrange
            var id = getRandomID();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclModuleRouteUrl.View.Replace("{id}",id.ToString()), Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");


            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void EditByIdModuleTest()
        {
            //Arrange

            var data = GetModule();
            var id = getRandomID();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclModuleRouteUrl.Edit.Replace("{id}",id.ToString()),Method.Put);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void DeleteByIdModuleTest()
        {

            var id = getRandomID();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclModuleRouteUrl.Destroy.Replace("{id}",id.ToString()), Method.Delete);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        private AclModuleRequest GetModule()
        {
            var faker = new Faker();
            return new AclModuleRequest
            {
                Name = faker.Random.String2(10, 50),
                Icon = faker.Random.String2(1, 5),
                Sequence = faker.Random.Number(1, 3),
                DisplayName = faker.Random.String2(1, 5)
            };

        }

        private int getRandomID()
        {

            return (int)DataCollectors.unitOfWork.ApplicationDbContext.AclModules.Max(i=>i.Id);

        }

    }
}