using ACL.Requests;
using ACL.Services;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
using ACL.Database.Models;
using ACL.Requests.V1;

namespace ACL.Tests.V1
{
    public class AclPageUnitTest
    {
        DatabaseConnector dbConnector;
        CustomUnitOfWork unitOfWork;
        RestClient restClient;
        public AclPageUnitTest()
        {
            dbConnector = new DatabaseConnector();
            unitOfWork = new CustomUnitOfWork(dbConnector.dbContext);
            unitOfWork.ApplicationDbContext = dbConnector.dbContext;
            restClient = new RestClient(dbConnector.baseUrl);
        }
        [Fact]
        public void TestPageList()
        {

            //Arrange

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclPageRouteUrl.List, Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void AddPageTest()
        {
            //Arrange
            var data = GetPage();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclPageRouteUrl.Add, Method.Post);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        [Fact]
        public void GetByIdPageTest()
        {
            //Arrange
            var id = getRandomID();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclPageRouteUrl.View.Replace("{id}",id.ToString()), Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");


            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void EditByIdPageTest()
        {
            //Arrange

            var data = GetPage();
            var id = getRandomID();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclPageRouteUrl.Edit.Replace("{id}",id.ToString()), Method.Put);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void DeleteByIdPageTest()
        {

            var id = getRandomID();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclModuleRouteUrl.Destroy.Replace("{id}",id.ToString()), Method.Delete);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        private AclPageRequest GetPage()
        {
            var faker = new Faker();
            return new AclPageRequest
            {
                ModuleId = (ulong)faker.Random.Number(1001, 1002),
                SubModuleId = (ulong)faker.Random.Number(2052, 2054),
                Name = faker.Random.String2(10, 50),
                MethodName = faker.Random.String2(1, 5),
                MethodType = faker.Random.Number(1, 3),
            };

        }

        private ulong getRandomID()
        {

            return unitOfWork.ApplicationDbContext.AclPages.Max(x => x.Id);

        }

    }
}