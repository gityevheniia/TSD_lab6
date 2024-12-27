using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Remoting.Contexts;

namespace DAL.Tests
{
    // Тестовий клас репозиторію для перевірки базового функціоналу
    public class TestUserRepository : BaseRepository<User>
    {
        public TestUserRepository(DbContext context) : base(context) { }
    }

    public class BaseRepositoryUnitTests
    {
        private Mock<DbContext> CreateMockDbContext<T>(Mock<DbSet<T>> mockDbSet) where T : class
        {
            var mockContext = new Mock<DbContext>(new DbContextOptions<DbContext>());
            mockContext.Setup(context => context.Set<T>()).Returns(mockDbSet.Object);
            return mockContext;
        }

        [Fact]
        public void Create_InputUserInstance_CalledAddMethodOfDBSetWithUserInstance()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<User>>();
            var mockContext = CreateMockDbContext(mockDbSet);

            var repository = new TestUserRepository(mockContext.Object);
            var expectedUser = new User { Id = 1, Name = "Test User", Role = "Operator" };

            // Act
            repository.Create(expectedUser);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Add(expectedUser), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<User>>();
            var mockContext = CreateMockDbContext(mockDbSet);

            var expectedUser = new User { Id = 1, Name = "Test User", Role = "Operator" };
            mockDbSet.Setup(dbSet => dbSet.Find(expectedUser.Id)).Returns(expectedUser);

            var repository = new TestUserRepository(mockContext.Object);

            // Act
            var actualUser = repository.Get(expectedUser.Id);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedUser.Id), Times.Once());
            Assert.Equal(expectedUser, actualUser);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<User>>();
            var mockContext = CreateMockDbContext(mockDbSet);

            var expectedUser = new User { Id = 1, Name = "Test User", Role = "Operator" };
            mockDbSet.Setup(dbSet => dbSet.Find(expectedUser.Id)).Returns(expectedUser);

            var repository = new TestUserRepository(mockContext.Object);

            // Act
            repository.Delete(expectedUser.Id);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedUser.Id), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expectedUser), Times.Once());
        }

        [Fact]
        public void GetAll_NoInput_ReturnsAllUsers()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<User>>();
            var mockContext = CreateMockDbContext(mockDbSet);

            var expectedUsers = new List<User>
            {
                new User { Id = 1, Name = "User1", Role = "Operator" },
                new User { Id = 2, Name = "User2", Role = "Supervisor" }
            }.AsQueryable();

            mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(expectedUsers.Provider);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(expectedUsers.Expression);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(expectedUsers.ElementType);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(expectedUsers.GetEnumerator());

            var repository = new TestUserRepository(mockContext.Object);

            // Act
            var actualUsers = repository.GetAll();

            // Assert
            Assert.Equal(expectedUsers.Count(), actualUsers.Count());
            Assert.Contains(expectedUsers.First(), actualUsers);
        }
    }
}
