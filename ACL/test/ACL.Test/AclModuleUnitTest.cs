using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using Bogus;
using Newtonsoft.Json;
using RestSharp;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS0414 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS1998 // Converting null literal or possible null value to non-nullable type.
namespace ACL.TEST
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
            var request = new RestRequest(AclRoutesUrl.AclModuleRouteUrl.List, Method.Get);
            request.AddHeader("Authorization", DataCollectors.GetAuthorization());

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }
        [Fact]
        public void AddModuleTest()
        {
            //Arrange
            var data = GetModule();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclModuleRouteUrl.Add, Method.Post);
            request.AddHeader("Authorization", DataCollectors.GetAuthorization());
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }
        [Fact]
        public void EditByIdModuleTest()
        {
            //Arrange

            var data = GetModule();
            var id = GetRandomID();
            data.Id = id;

            // Act
            var request = new RestRequest(AclRoutesUrl.AclModuleRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
             request.AddHeader("Authorization", DataCollectors.GetAuthorization());
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }
        [Fact]
        public void GetByIdModuleTest()
        {
            //Arrange
            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclModuleRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);
            request.AddHeader("Authorization", DataCollectors.GetAuthorization());


            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }

        [Fact]
        public void DeleteByIdModuleTest()
        {

            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclModuleRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            request.AddHeader("Authorization", DataCollectors.GetAuthorization());

            RestResponse response = restClient.Execute(request);

            // Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

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

        private ulong GetRandomID()
        {

            return (ulong)DataCollectors.dbContext.AclModules.Max(i => i.Id);

        }

    }
}