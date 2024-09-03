using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Web.Presentation.Routes;
using Bogus;
using Newtonsoft.Json;
using RestSharp;
using SharedKernel.Main.Contracts;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS0414 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS1998 // Converting null literal or possible null value to non-nullable type.
namespace ACL.TEST
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
            var request = new RestRequest(AclRoutesUrl.AclPageRouteRouteUrl.Add, Method.Post);
            request.AddHeader("Authorization", DataCollectors.GetAuthorization());
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                       ApplicationResponse applicationResponse = JsonConvert.DeserializeObject<ApplicationResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, applicationResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }

        [Fact]
        public void EditByIdPageRouteTest()
        {
            //Arrange

            var data = GetPageRoute();
            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPageRouteRouteUrl.Edit.Replace("{id}",id.ToString()), Method.Put);
            request.AddHeader("Authorization", DataCollectors.GetAuthorization());
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                       ApplicationResponse applicationResponse = JsonConvert.DeserializeObject<ApplicationResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, applicationResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }
        [Fact]
        public void DeleteByIdPageRouteTest()
        {

            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPageRouteRouteUrl.Destroy.Replace("{id}",id.ToString()), Method.Delete);
             request.AddHeader("Authorization", DataCollectors.GetAuthorization());

            RestResponse response = restClient.Execute(request);

            // Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                       ApplicationResponse applicationResponse = JsonConvert.DeserializeObject<ApplicationResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, applicationResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }

        private AclPageRouteRequest GetPageRoute()
        {
            var faker = new Faker();
            return new AclPageRouteRequest
            {
                PageId = (uint)faker.Random.Number(3001, 3004),
                RouteName = faker.Random.String2(10, 50),
                RouteUrl = faker.Random.String2(10, 50),
            };
        }

        private uint GetRandomID()
        {

            return DataCollectors.dbContext.AclPageRoutes.Max(x => x.Id);

        }

    }
}