using ACL.App.Infrastructure.Route;
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
    public class AclUserGrouRoleUnitTest
    {
        RestClient restClient;
        private string authToken;
        public AclUserGrouRoleUnitTest()
        {
            DataCollectors.SetDatabase();
            authToken = DataCollectors.GetAuthorization("sadmin");
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public void GetUserGroupRoleTest()
        {

            //Arrange
            var userGroupId = DataCollectors.GetMaxId<AclUsergroup>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclUserGroupRoleRouteUrl.List.Replace("{userGroupId}", userGroupId.ToString()), Method.Get);
            request.AddHeader("Authorization", authToken);

            RestResponse response = restClient.Execute(request);

            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void UpdateUserGroupRoleTest()
        {
            //Arrange
            var data = GetUserGroupRole();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclUserGroupRoleRouteUrl.Update, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);

            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }


        private AclUserGroupRoleRequest GetUserGroupRole()
        {
            ulong maxId = DataCollectors.dbContext.AclRoles.Max(i => i.Id);
            ulong[] idArray = new ulong[] { maxId };
            return new AclUserGroupRoleRequest
            {
                UserGroupId = DataCollectors.dbContext.AclUsergroups.Max(i => i.Id),
                RoleIds = idArray
            };

        }



    }
}