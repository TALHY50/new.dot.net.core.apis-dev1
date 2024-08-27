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
    public class AclPageUnitTest
    {
        RestClient restClient;
        public AclPageUnitTest()
        {
            DataCollectors.SetDatabase(false);
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public void TestPageList()
        {

            //Arrange

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPageRouteUrl.List, Method.Get);
            request.AddHeader("Authorization", DataCollectors.GetAuthorization());

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                       ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }
        [Fact]
        public void AddPageTest()
        {
            //Arrange
            var data = GetPage();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPageRouteUrl.Add, Method.Post);
           request.AddHeader("Authorization", DataCollectors.GetAuthorization());
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                       ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }
        [Fact]
        public void EditByIdPageTest()
        {
            //Arrange

            var data = GetPage();
            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPageRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
             request.AddHeader("Authorization", DataCollectors.GetAuthorization());
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                       ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }
        [Fact]
        public void GetByIdPageTest()
        {
            //Arrange
            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPageRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);
             request.AddHeader("Authorization", DataCollectors.GetAuthorization());

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                       ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }

        [Fact]
        public void DeleteByIdPageTest()
        {

            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPageRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
             request.AddHeader("Authorization", DataCollectors.GetAuthorization());

            RestResponse response = restClient.Execute(request);

            // Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                       ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, scopeResponse.StatusCode);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

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

        private ulong GetRandomID()
        {

            return DataCollectors.dbContext.AclPages.Max(x => x.Id);

        }

    }
}