using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DAL.Tests
{
    [TestClass]
    public class PassRepositoryTests
    {
        private DbContextOptions<AccessControlContext> _options;

        [TestInitialize]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<AccessControlContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [TestMethod]
        public void AddPass_ShouldAddPass()
        {
            using var context = new AccessControlContext(_options);
            var repository = new PassRepository(context);

            var pass = new Pass { PassNumber = "12345", EmployeeName = "John Doe", IsActive = true };
            repository.Add(pass);
            context.SaveChanges();

            Assert.AreEqual(1, context.Passes.Count());
        }
    }
}

