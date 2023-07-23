using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;
using Microsoft.EntityFrameworkCore;

namespace MedicalSuppliesDataTest
{
    [TestClass]
    public class MSDBContextTests
    {
       
        private MSDBContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<MSDBContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;                  

            return new MSDBContext(options);
        }

        [TestMethod]
        public void MSDBContext_ConnectToDatabase_Success()
        {
            using (var dbContext = GetDbContext())
            {
                // Act & Assert
                Assert.IsTrue(dbContext.Database.IsInMemory());
            }
        }

        [TestMethod]
        public void MSDBContext_AddCustomer_Success()
        {
            using (var dbContext = GetDbContext())
            {
                // Arrange
                var mockCustomer = new Customer { FirstName = "John", LastName = "Doe", Height = "180" };

                // Act
                dbContext.Customers.Add(mockCustomer);
                dbContext.SaveChanges();

                // Assert
                var savedCustomer = dbContext.Customers.FirstOrDefault(c => c.FirstName == "John" && c.LastName == "Doe");
                Assert.IsNotNull(savedCustomer);
            }
        }

        [TestMethod]
        public void MSDBContext_GetAllCustomers_Success()
        {
            using (var dbContext = GetDbContext()) 
            {
                //Arrange
                dbContext.SeedData(); 

                // Act
                var customers = dbContext.Customers.ToList();

                // Assert
                Assert.AreEqual(2, customers.Count); // We have 2 customers in the seed data
            }
        }



    }
}
