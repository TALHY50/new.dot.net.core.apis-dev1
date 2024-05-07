
using Microsoft.EntityFrameworkCore;
using RestSharp;
using ACL.Requests.V1;
using ACL.Route;
using ACL.Database.Models;
using SharedLibrary.Services;
using SharedLibrary.Response.CustomStatusCode;
using ACL.Response.V1;
using Newtonsoft.Json;

namespace ACL.Tests.V1
{
    public class AclUserGrouRoleUnitTest
    {
        RestClient restClient;
        private string authToken;
        public AclUserGrouRoleUnitTest()
        {
            DataCollectors.SetDatabase();
            authToken = DataCollectors.GetAuthorization();
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
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
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
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }


        private AclUserGroupRoleRequest GetUserGroupRole()
        {
            ulong maxId = DataCollectors.unitOfWork.ApplicationDbContext.AclRoles.Max(i => i.Id);
            ulong[] idArray = new ulong[] { maxId };
            return new AclUserGroupRoleRequest
            {
                UserGroupId = DataCollectors.unitOfWork.ApplicationDbContext.AclUsergroups.Max(i => i.Id),
                RoleIds = idArray
            };

        }



    }
}