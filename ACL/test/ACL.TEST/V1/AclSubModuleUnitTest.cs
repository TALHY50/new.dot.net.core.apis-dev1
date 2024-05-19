using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Core.Entities;
using ACL.Infrastructure.Route;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
using SharedLibrary.Response.CustomStatusCode;
using Newtonsoft.Json;

namespace ACL.Tests.V1
{
    public class AclSubModuleUnitTest
    {
        RestClient restClient;
        string authToken;
        public AclSubModuleUnitTest()
        {
            DataCollectors.SetDatabase();
            authToken = DataCollectors.GetAuthorization();
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public void TestSubModuleList()
        {

            //Arrange

            // Act
            var request = new RestRequest(AclRoutesUrl.AclSubmoduleRouteUrl.List, Method.Get);
            request.AddHeader("Authorization", authToken);
            RestResponse response = restClient.Execute(request);


            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void AddSubModuleTest()
        {
            //Arrange
            var data = GetSubModule();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclSubmoduleRouteUrl.Add, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void EditByIdSubModuleTest()
        {
            //Arrange

            var data = GetSubModule();
            var id = DataCollectors.dbContext.AclSubModules.Max(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclSubmoduleRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void GetByIdSubModuleTest()
        {
            //Arrange
            var id = DataCollectors.GetMaxId<AclSubModule>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclSubmoduleRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);
            request.AddHeader("Authorization", authToken);
            RestResponse response = restClient.Execute(request);


            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }

        [Fact]
        public void DeleteByIdSubModuleTest()
        {

            var id = DataCollectors.GetMaxId<AclSubModule>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclSubmoduleRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            request.AddHeader("Authorization", authToken);

            RestResponse response = restClient.Execute(request);

            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }

        private AclSubModuleRequest GetSubModule()
        {
            var faker = new Faker();
            return new AclSubModuleRequest
            {
                Id = (ulong)faker.Random.Number(1, int.MaxValue),
                ModuleId = DataCollectors.GetMaxId<AclModule>(x => x.Id),
                Name = faker.Random.String2(10, 50),
                ControllerName = faker.Random.String2(10, 50),
                DefaultMethod = faker.Random.String2(10, 50),
                DisplayName = faker.Random.String2(10, 50),
                Sequence = faker.Random.Number(1, int.MaxValue),
                Icon = faker.Random.String2(10, 100)

            };

        }



    }
}