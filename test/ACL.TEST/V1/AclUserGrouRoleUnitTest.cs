
using ACL.Services;
using Microsoft.EntityFrameworkCore;
using RestSharp;

using ACL.Requests.V1;

namespace ACL.Tests.V1
{
    public class AclUserGrouRoleUnitTest
    {
        DatabaseConnector dbConnector;
        UnitOfWork unitOfWork;
        RestClient restClient;
        public AclUserGrouRoleUnitTest()
        {
            dbConnector = new DatabaseConnector();
            unitOfWork = new UnitOfWork(dbConnector.dbContext);
            unitOfWork.ApplicationDbContext = dbConnector.dbContext;
            restClient = new RestClient(dbConnector.baseUrl);
        }
        [Fact]
        public void GetUserGroupRoleTest()
        {
          
            //Arrange
            var userGroupId = getRandomID();

            // Act
            var request = new RestRequest($"usergroups/roles/{userGroupId}", Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");

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
            var request = new RestRequest($"usergroups/roles/update", Method.Post);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

     
        private AclUserGroupRoleRequest GetUserGroupRole()
        {
            return new AclUserGroupRoleRequest
            {
                user_group_id = getRandomID(),
                role_ids = new ulong[]  { getRandomRoleID() }
            };

        }

        private ulong getRandomID()
        {
            return unitOfWork.ApplicationDbContext.AclUsergroups.Max(x=>x.Id);
        }
        private ulong getRandomRoleID()
        {
            return unitOfWork.ApplicationDbContext.AclRoles.Max(x => x.Id);
        }


    }
}