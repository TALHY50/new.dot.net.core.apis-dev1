
using Microsoft.EntityFrameworkCore;
using RestSharp;
using ACL.Requests.V1;
using ACL.Route;
using ACL.Database.Models;

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
            var request = new RestRequest(AclRoutesUrl.AclUserGroupRole.List.Replace("{userGroupId}", userGroupId.ToString()), Method.Get);
            request.AddHeader("Authorization", authToken);

            RestResponse response = restClient.Execute(request);

          
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void UpdateUserGroupRoleTest()
        {
            //Arrange
            var data = GetUserGroupRole();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclUserGroupRole.Update, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

     
        private AclUserGroupRoleRequest GetUserGroupRole()
        {
            return new AclUserGroupRoleRequest
            {
                user_group_id = DataCollectors.GetMaxId<AclUsergroup>(x => x.Id),
                role_ids = new ulong[]  { DataCollectors.GetMaxId<AclRole>(x => x.Id)}
            };

        }

       

    }
}