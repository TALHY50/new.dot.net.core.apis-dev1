using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Infrastructure.Route;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
using SharedLibrary.Response.CustomStatusCode;
using Newtonsoft.Json;

namespace ACL.Tests.V1
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
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);


            //// Assert
                       AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void AddPageTest()
        {
            //Arrange
            var data = GetPage();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPageRouteUrl.Add, Method.Post);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
                       AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void EditByIdPageTest()
        {
            //Arrange

            var data = GetPage();
            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPageRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
                       AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void GetByIdPageTest()
        {
            //Arrange
            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPageRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");


            RestResponse response = restClient.Execute(request);


            //// Assert
                       AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }

        [Fact]
        public void DeleteByIdPageTest()
        {

            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPageRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);

            // Assert
                       AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

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