using ACL.Controllers.V1;
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Response.V1;
using FakeItEasy;

namespace ACL.Tests
{
    public class AclCompanyControllerTest
    {
        [Fact]
        public async Task Get_All_Returns_The_Correct_Number_Of_Acompanies()
        {
            //Arrange
            int count = 3;
            var dataStore = A.Fake<IUnitOfWork>();
            var fakeCompanies = A.CollectionOfDummy<AclCompany>(0).AsEnumerable();
            A.CallTo(() => dataStore.AclCompanyRepository.GetAll());

            var controller = new AclCompanyController(dataStore);

            //Act
            var aclResponse = await controller.Index();
            
            //Assert
            var result = aclResponse;
            List<AclCompany> returnCompanies = (List<AclCompany>)aclResponse.Data;
            Assert.Equal(count,returnCompanies.Count);
        }
    }
}