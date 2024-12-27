using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Impl;

namespace DAL.Tests
{
    public class RepositoryUnitTests
    {
        [Fact]
        public void Add_InputPassInstance_CalledAddMethodOfDbSet()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AccessControlContext>().Options;
            var mockContext = new Mock<AccessControlContext>(options);
            var mockDbSet = new Mock<DbSet<Pass>>();
            mockContext.Setup(context => context.Set<Pass>()).Returns(mockDbSet.Object);


            var repository = new PassRepository(mockContext.Object);
            var expectedPass = new Pass { Id = 1, PassNumber = "12345", EmployeeName = "John Doe", IsActive = true };

            // Act
            repository.Add(expectedPass);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Add(expectedPass), Times.Once());
        }

        [Fact]
        public void GetById_InputPassId_CalledFindMethodOfDbSet()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AccessControlContext>().Options;
            var mockContext = new Mock<AccessControlContext>(options);
            var mockDbSet = new Mock<DbSet<Pass>>();
            mockContext.Setup(context => context.Set<Pass>()).Returns(mockDbSet.Object);

            var repository = new PassRepository(mockContext.Object);
            var expectedPass = new Pass { Id = 1, PassNumber = "21345" };

            mockDbSet.Setup(dbSet => dbSet.Find(expectedPass.Id)).Returns(expectedPass);
            //mockDbSet.Setup(dbSet => dbSet.Find(It.IsAny<int>())).Returns((Pass)null);  

            // Act
            var actualPass = repository.GetById(expectedPass.Id);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedPass.Id), Times.Once());
            Assert.Equal(expectedPass, actualPass);
        }

        [Fact]
        public void Delete_InputPassInstance_CalledRemoveMethodOfDbSet()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AccessControlContext>().Options;
            var mockContext = new Mock<AccessControlContext>(options);
            var mockDbSet = new Mock<DbSet<Pass>>();
            mockContext.Setup(context => context.Set<Pass>()).Returns(mockDbSet.Object);
          //  mockDbSet.Setup(dbSet => dbSet.Remove(It.IsAny<Pass>())).Throws(new Exception("Failed to remove"));


            var repository = new PassRepository(mockContext.Object);
            var passToDelete = new Pass { Id = 1, PassNumber = "12345" };

            // Act
            repository.Delete(passToDelete);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Remove(passToDelete), Times.Once());
        }

        [Fact]
        public void Update_InputAccessRequestInstance_CalledUpdateMethodOfDbSet()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AccessControlContext>().Options;
            var mockContext = new Mock<AccessControlContext>(options);
            var mockDbSet = new Mock<DbSet<AccessRequest>>();
            mockContext.Setup(context => context.Set<AccessRequest>()).Returns(mockDbSet.Object);

            var repository = new AccessRequestRepository(mockContext.Object);
            var requestToUpdate = new AccessRequest { Id = 1, RequestedZone = "Zone A", IsApproved = false };

            // Act
            repository.Update(requestToUpdate);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Update(requestToUpdate), Times.Once());
        }
    }
}
