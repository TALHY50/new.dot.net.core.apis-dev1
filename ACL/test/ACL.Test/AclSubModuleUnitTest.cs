using ACL.App.Infrastructure.Route;
using Bogus;
using Newtonsoft.Json;
using RestSharp;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Domain.Module;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS0414 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS1998 // Converting null literal or possible null value to non-nullable type.
namespace ACL.TEST
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
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
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
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
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
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
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
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
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
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
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