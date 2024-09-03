//using ACL.Requests;
//using ACL.Services;
//using ACL.Controllers.V1;
//using ACL.Responses.V1;
//using Bogus;
//using ACL.Tests;

//namespace Test
//{
//    public class AclRolesUnitTest
//    {
//        DatabaseConnector dbConnector;
//        CustomUnitOfWork unitOfWork;
//        RoleController controller;
//        public AclRolesUnitTest()
//        {
//            dbConnector = new DatabaseConnector();
//            unitOfWork = new CustomUnitOfWork(dbConnector.dbContext);
//            dbContext = dbConnector.dbContext;
//            controller = new RoleController(unitOfWork);
//        }
//        [Fact]
//        public async void GetAllRolesTest()
//        {

//            // Act
//            var ScopeResponse = await controller.Index();


//            // Assert
//            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)ScopeResponse.StatusCode);

//        }
//        [Fact]
//        public async void AddRoleTest()
//        {
//            var data = GetRole();

//            // Act
//            ScopeResponse ScopeResponse = await controller.CreateCompanyModule(data);

//            int actualStatusCode = (int)ScopeResponse.StatusCode;

//            //// Assert
//            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);

//        }

//        [Fact]
//        public async void GetByIdRoleTest()
//        {

//            var id = GetRandomID();


//            // Act
//            ScopeResponse ScopeResponse = await controller.View(id);

//            int actualStatusCode = (int)ScopeResponse.StatusCode;

//            //// Assert
//            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);

//        }
//        [Fact]
//        public async void EditByIdRoleTest()
//        {
//            var data = GetRole();
//            var id = GetRandomID();


//            // Act
//            ScopeResponse ScopeResponse = await controller.Edit(id, data);

//            int actualStatusCode = (int)ScopeResponse.StatusCode;

//            //// Assert
//            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);

//        }
//        [Fact]
//        public async void DeleteByIdRoleTest()
//        {

//            var id = GetRandomID();

//            // Act
//            ScopeResponse ScopeResponse = await controller.Destroy(id);

//            int actualStatusCode = (int)ScopeResponse.StatusCode;

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

//        private uint GetRandomID()
//        {

//            return dbContext.AclRoles.FirstOrDefault().Id;

//        }

//    }
//}