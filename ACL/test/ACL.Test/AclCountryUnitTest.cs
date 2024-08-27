using Bogus;
using Newtonsoft.Json;
using RestSharp;
using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS0414 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS1998 // Converting null literal or possible null value to non-nullable type.
namespace ACL.TEST
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
            var request = new RestRequest(AclRoutesUrl.AclCountryRouteUrl.List, Method.Get);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            RestResponse response = restClient.Execute(request);

            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }
        [Fact]
        public void AddCountryTest()
        {
            //Arrange
            var data = GetCountry();
            // Act
            var request = new RestRequest(AclRoutesUrl.AclCountryRouteUrl.Add, Method.Post);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            request.AddJsonBody(data);
            RestResponse response = restClient.Execute(request);
            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }
        [Fact]
        public void EditByIdCountryTest()
        {
            //Arrange

            var data = GetCountry();
            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclCountryRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }
        [Fact]
        public void GetByIdCountryTest()
        {
            //Arrange
            var id = GetRandomID();
            // Act
            var request = new RestRequest(AclRoutesUrl.AclCountryRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            RestResponse response = restClient.Execute(request);
            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }

        [Fact]
        public void DeleteByIdCountryTest()
        {

            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclCountryRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);

            RestResponse response = restClient.Execute(request);

            // Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

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

        private ulong GetRandomID()
        {

            return DataCollectors.dbContext.AclCountries.Max(x => x.Id);

        }

    }
}