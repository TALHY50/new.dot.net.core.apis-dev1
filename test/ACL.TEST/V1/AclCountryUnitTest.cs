using ACL.Requests;
using ACL.Services;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
using ACL.Database.Models;
using ACL.Requests.V1;
using SharedLibrary.Services;
using ACL.Response.V1;
using Newtonsoft.Json;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Tests.V1
{
    public class AclCountryUnitTest
    {
        RestClient restClient;
        public AclCountryUnitTest()
        {
             DataCollectors.SetDatabase(false);
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public void TestCountryList()
        {

            //Arrange
            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclCountryRouteUrl.List, Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");
            RestResponse response = restClient.Execute(request);
            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void AddCountryTest()
        {
            //Arrange
            var data = GetCountry();
            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclCountryRouteUrl.Add, Method.Post);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);
            RestResponse response = restClient.Execute(request);
            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }

        [Fact]
        public void GetByIdCountryTest()
        {
            //Arrange
            var id = getRandomID();
            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclCountryRouteUrl.View.Replace("{id}",id.ToString()), Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");
            RestResponse response = restClient.Execute(request);
            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void EditByIdCountryTest()
        {
            //Arrange

            var data = GetCountry();
            var id = getRandomID();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclCountryRouteUrl.Edit.Replace("{id}",id.ToString()), Method.Put);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void DeleteByIdCountryTest()
        {

            var id = getRandomID();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclCountryRouteUrl.Destroy.Replace("{id}",id.ToString()), Method.Delete);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);

            // Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }

        private AclCountryRequest GetCountry()
        {
            var faker = new Faker();
            return new AclCountryRequest
            {
                Name = faker.Random.String2(10, 50),
                Description = faker.Random.String2(10, 100),
                Code = faker.Random.String2(2, 5),
                Status = (byte)faker.Random.Number(1, 2),
                Sequence = (ulong)faker.Random.Number(10, 200),
            };

        }

        private ulong getRandomID()
        {

            return DataCollectors.unitOfWork.ApplicationDbContext.AclCountries.Max(x => x.Id);

        }

    }
}