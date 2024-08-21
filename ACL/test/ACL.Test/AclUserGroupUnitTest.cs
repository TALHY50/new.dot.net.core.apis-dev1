using ACL.App.Infrastructure.Route;
using Bogus;
using Newtonsoft.Json;
using RestSharp;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Domain.UserGroup;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS0414 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS1998 // Converting null literal or possible null value to non-nullable type.
namespace ACL.TEST
{
    public class AclUserGroupUnitTest
    {
        RestClient restClient;
        private string authToken;
        public AclUserGroupUnitTest()
        {
            DataCollectors.SetDatabase();
            authToken = DataCollectors.GetAuthorization("sadmin");
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public void UserGroupListTest()
        {

            //Arrange

            // Act
            var request = new RestRequest(AclRoutesUrl.AclUserGroupRouteUrl.List, Method.Get);
            request.AddHeader("Authorization", authToken);

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void AddUserGroupTest()
        {
            //Arrange
            var data = GetUserGroup();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclUserGroupRouteUrl.Add, Method.Post);
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
        public void EditByIdUserGroupTest()
        {
            //Arrange

            var data = GetUserGroup();
            var id = DataCollectors.GetMaxId<AclUsergroup>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclUserGroupRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
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
        public void GetByIdUserGroupTest()
        {
            //Arrange
            var id = DataCollectors.GetMaxId<AclUsergroup>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclUserGroupRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);
            request.AddHeader("Authorization", authToken);
            RestResponse response = restClient.Execute(request);
            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }

        [Fact]
        public void DeleteByIdUserGroupTest()
        {

            var id = DataCollectors.GetMaxId<AclUsergroup>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclUserGroupRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            request.AddHeader("Authorization", authToken);

            RestResponse response = restClient.Execute(request);

            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }

        private AclUserGroupRequest GetUserGroup()
        {
            var faker = new Faker();
            return new AclUserGroupRequest
            {
                Name = faker.Random.String2(10, 50),
                Status = (sbyte)faker.Random.Number(1, 2),
                GroupName = faker.Random.String2(10, 50)

            };

        }

    }
}