using ACL.Requests;
using ACL.Services;
using Bogus;
using Microsoft.EntityFrameworkCore;
using ACL.Database;
using ACL.Controllers.V1;
using ACL.Response.V1;

namespace ACL.Tests
{
    public class AclRoleUnitTest
    {
        ApplicationDbContext dbContext;
        UnitOfWork unitOfWork;
        private string connectionString;
        public AclRoleUnitTest()
        {
            var server = "127.0.0.1";
            var database = "acl_db";
            var userName = "root";
            var password = "";
            this.connectionString = $"server={server};database={database};User ID={userName};Password={password};";

            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseMySQL(connectionString).Options;
            dbContext = new ApplicationDbContext(options);
            unitOfWork = new UnitOfWork(dbContext);
            unitOfWork.ApplicationDbContext = dbContext;
        }
        [Fact]
        public async void GetAllRolesTest()
        {

            var controller = new AclRoleController(unitOfWork);

            // Act
            var aclResponse = await controller.Index();
           

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)aclResponse.StatusCode);

        }
        [Fact]
        public async void AddRoleTest()
        {
            var data = GetRole();

            var controller = new AclRoleController(unitOfWork);

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

            var controller = new AclRoleController(unitOfWork);

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

            var controller = new AclRoleController(unitOfWork);

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

            var controller = new AclRoleController(unitOfWork);

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