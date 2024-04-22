using ACL.Controllers.V1;
using ACL.Database;
using ACL.Database.Models;
using ACL.Response.V1;
using ACL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

public class AclCompanyControllerIntegrationTest
{
    [Fact]
    public async Task Get_All_Returns_The_Correct_Number_Of_Acompanies_Test()
    {
        #region arrange

        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "acl")
            .Options;

        using (var dbContext = new ApplicationDbContext(options))
        {
            // Populate the in-memory database with test data
            dbContext.AclCompanies.AddRange(new List<AclCompany>
            {
                new AclCompany{ Id = 1,AddedBy = 1,Address1 ="A",Address2 ="B",AverageTurnover=2.0,Cemail ="",City ="Dhaka",CmmiLevel = 1,Cname ="Porosh",Country="BD",Email="porosh@gmail.com",Fax="",Logo="",Name="Porosh",Phone="01672896992" ,Postcode ="1312",RegistrationNo="1234",State = "1",TaxNo="123456789",Timezone =1,TimezoneValue ="1",Status=1}
            });
            dbContext.SaveChanges();
        }
        #endregion
        using (var dbContext = new ApplicationDbContext(options))
        {
            // Use a genuine instance of UnitOfWork
            var unitOfWork = new UnitOfWork(dbContext);
            unitOfWork.ApplicationDbContext = dbContext;
            // unitOfWork.LocalizationService = 
            var controller = new AclCompanyController(unitOfWork);
            #region Act
            // Act
            var aclResponse = await controller.Index();
            #endregion

            #region Assert
            // Assert

            var res = aclResponse as AclResponse;
            var returnCompanies = res.Data as IEnumerable<AclCompany>;

            Assert.Equal(1, returnCompanies?.Count()); // Adjust count as per your test data
            #endregion
        }
    }
}


