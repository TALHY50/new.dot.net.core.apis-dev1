using ACL.Requests;
using ACL.Services;
using Bogus;
using ACL.Controllers.V1;
using ACL.Response.V1;

namespace ACL.Tests
{
    public class AclRoleUnitTest
    {
        DatabaseConnector  dbConnector;
        UnitOfWork unitOfWork;
        AclRoleController controller;
        public AclRoleUnitTest()
        {
            dbConnector = new DatabaseConnector();
            unitOfWork = new UnitOfWork(dbConnector.dbContext);
            unitOfWork.ApplicationDbContext = dbConnector.dbContext;
            controller = new AclRoleController(unitOfWork);
        }
        [Fact]
        public async void GetAllRolesTest()
        {

            // Act
            var aclResponse = await controller.Index();
           

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)aclResponse.StatusCode);

        }
        [Fact]
        public async void AddRoleTest()
        {
            var data = GetRole();

            // Act
            AclResponse aclResponse = await controller.Create(data);
           
            int actualStatusCode = (int)aclResponse.StatusCode;

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);

        }

        [Fact]
        public async void GetByIdRoleTest()
        {
            
            var id = getRandomID();


            // Act
            AclResponse aclResponse = await controller.View(id);

            int actualStatusCode = (int)aclResponse.StatusCode;

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);

        }
        [Fact]
        public async void EditByIdRoleTest()
        {
            var data = GetRole();
            var id = getRandomID();


            // Act
            AclResponse aclResponse = await controller.Edit(id,data);

            int actualStatusCode = (int)aclResponse.StatusCode;

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);

        }
        [Fact]
        public async void DeleteByIdRoleTest()
        {
           
            var id = getRandomID();

            // Act
            AclResponse aclResponse = await controller.Destroy(id);

            int actualStatusCode = (int)aclResponse.StatusCode;

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);

        }

        private AclRoleRequest GetRole()
        {
            var faker = new Faker();
            return new AclRoleRequest
            {
                name = faker.Lorem.Sentence(5),
                status = (sbyte)faker.Random.Number(1, 2),
                title = faker.Lorem.Sentence(5)
            };

        }

        private ulong getRandomID()
        {
           
            return unitOfWork.ApplicationDbContext.AclRoles.FirstOrDefault().Id;
           
        }

    }
}