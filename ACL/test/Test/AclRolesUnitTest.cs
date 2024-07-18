//using ACL.Requests;
//using ACL.Services;
//using ACL.Controllers.V1;
//using ACL.Response.V1;
//using Bogus;
//using ACL.Tests;

//namespace Test
//{
//    public class AclRolesUnitTest
//    {
//        DatabaseConnector dbConnector;
//        CustomUnitOfWork unitOfWork;
//        AclRoleController controller;
//        public AclRolesUnitTest()
//        {
//            dbConnector = new DatabaseConnector();
//            unitOfWork = new CustomUnitOfWork(dbConnector.dbContext);
//            dbContext = dbConnector.dbContext;
//            controller = new AclRoleController(unitOfWork);
//        }
//        [Fact]
//        public async void GetAllRolesTest()
//        {

//            // Act
//            var AclResponse = await controller.Index();


//            // Assert
//            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)AclResponse.StatusCode);

//        }
//        [Fact]
//        public async void AddRoleTest()
//        {
//            var data = GetRole();

//            // Act
//            AclResponse AclResponse = await controller.Create(data);

//            int actualStatusCode = (int)AclResponse.StatusCode;

//            //// Assert
//            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);

//        }

//        [Fact]
//        public async void GetByIdRoleTest()
//        {

//            var id = GetRandomID();


//            // Act
//            AclResponse AclResponse = await controller.View(id);

//            int actualStatusCode = (int)AclResponse.StatusCode;

//            //// Assert
//            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);

//        }
//        [Fact]
//        public async void EditByIdRoleTest()
//        {
//            var data = GetRole();
//            var id = GetRandomID();


//            // Act
//            AclResponse AclResponse = await controller.Edit(id, data);

//            int actualStatusCode = (int)AclResponse.StatusCode;

//            //// Assert
//            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);

//        }
//        [Fact]
//        public async void DeleteByIdRoleTest()
//        {

//            var id = GetRandomID();

//            // Act
//            AclResponse AclResponse = await controller.Destroy(id);

//            int actualStatusCode = (int)AclResponse.StatusCode;

//            //// Assert
//            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);

//        }

//        private AclRoleRequest GetRole()
//        {
//            var faker = new Faker();
//            return new AclRoleRequest
//            {
//                name = faker.Lorem.Sentence(5),
//                status = (sbyte)faker.Random.Number(1, 2),
//                title = faker.Lorem.Sentence(5)
//            };

//        }

//        private ulong GetRandomID()
//        {

//            return dbContext.AclRoles.FirstOrDefault().Id;

//        }

//    }
//}