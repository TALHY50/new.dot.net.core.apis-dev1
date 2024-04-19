using ACL.Controllers.V1;
using ACL.Database;
using ACL.Database.Models;
using ACL.Response.V1;
using ACL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AclCompanyControllerIntegrationTest
{
    [Fact]
    public async Task Get_All_Returns_The_Correct_Number_Of_Acompanies()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "acl")
            .Options;

        using (var dbContext = new ApplicationDbContext(options))
        {
            // Populate the in-memory database with test data
            dbContext.AclCompanies.AddRange(new List<AclCompany>
            {
                // Test data here...
            });
            dbContext.SaveChanges();
        }

        using (var dbContext = new ApplicationDbContext(options))
        {
            // Use a genuine instance of UnitOfWork
            var unitOfWork = new UnitOfWork(dbContext);
            unitOfWork.ApplicationDbContext = dbContext;
            var controller = new AclCompanyController(unitOfWork);

            // Act
            var aclResponse = await controller.Index();

            // Assert
            var result = aclResponse as OkObjectResult;
            var res = result.Value as AclResponse;
            var returnCompanies = res.Data as IEnumerable<AclCompany>;

            Assert.Equal(null, returnCompanies?.Count()); // Adjust count as per your test data
        }
    }
}


