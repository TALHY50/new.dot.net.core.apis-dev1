using ACL.Requests;
using ACL.Services;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
using ACL.Database.Models;
using ACL.Requests.V1;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Tests.V1
{
    public class AclPageRouteUnitTest
    {
      
        RestClient restClient;
        public AclPageRouteUnitTest()
        {
             DataCollectors.SetDatabase(false);
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public void AddPageRouteTest()
        {
            //Arrange
            var data = GetPageRoute();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclPageRouteRouteUrl.Add, Method.Post);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, (int)response.StatusCode);

        }

        [Fact]
        public void EditByIdPageRouteTest()
        {
            //Arrange

            var data = GetPageRoute();
            var id = GetRandomID();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclPageRouteRouteUrl.Edit.Replace("{id}",id.ToString()), Method.Put);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, (int)response.StatusCode);

        }
        [Fact]
        public void DeleteByIdPageRouteTest()
        {

            var id = GetRandomID();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclPageRouteRouteUrl.Destroy.Replace("{id}",id.ToString()), Method.Delete);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, (int)response.StatusCode);

        }

        private AclPageRouteRequest GetPageRoute()
        {
            var faker = new Faker();
            return new AclPageRouteRequest
            {
                PageId = (ulong)faker.Random.Number(3001, 3004),
                RouteName = faker.Random.String2(10, 50),
                RouteUrl = faker.Random.String2(10, 50),
            };
        }

        private ulong GetRandomID()
        {

            return DataCollectors.unitOfWork.ApplicationDbContext.AclPageRoutes.Max(x => x.Id);

        }

    }
}