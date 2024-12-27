using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;
using Xunit;

namespace BLL.Tests
{
    public class PassServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PassService(nullUnitOfWork));
        }

        [Fact]
        public void GetActivePasses_UserIsNotAuthorized_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Employee(1, "Іван", "Петренко", "ivan.petrenko@example.com");
            SecurityContext.SetUser(user);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IPassService passService = new PassService(mockUnitOfWork.Object);

            // Act & Assert
            Assert.Throws<MethodAccessException>(() => passService.GetActivePasses(1));
        }

        [Fact]
        public void GetActivePasses_PassFromDAL_CorrectMappingToPassDTO()
        {
            // Arrange
            User user = new SecurityOfficer(1, "Олександр", "Ковальчук", "oleksandr.kovalchuk@example.com");
            SecurityContext.SetUser(user);

            var passService = GetPassService();

            // Act
            var actualPassDto = passService.GetActivePasses(1).First();

            // Assert
            Assert.True(actualPassDto.Id == 1);
            Assert.True(actualPassDto.PassNumber == "ABC123");
            Assert.True(actualPassDto.EmployeeName == "John Doe");
            Assert.True(actualPassDto.IsActive);
        }

        [Fact]
        public void DeactivatePass_ValidCall_PassDeactivated()
        {
            // Arrange
            User user = new SecurityOfficer(1, "Олександр", "Ковальчук", "oleksandr.kovalchuk@example.com");
            SecurityContext.SetUser(user);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockPassRepository = new Mock<IPassRepository>();
            mockUnitOfWork.Setup(u => u.PassRepository).Returns(mockPassRepository.Object);

            IPassService passService = new PassService(mockUnitOfWork.Object);

            // Act
            passService.DeactivatePass(1);

            // Assert
            mockPassRepository.Verify(repo => repo.DeactivatePass(1), Times.Once);
            mockUnitOfWork.Verify(u => u.Save(), Times.Once);
        }

        private IPassService GetPassService()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var expectedPass = new Pass
            {
                Id = 1,
                PassNumber = "ABC123",
                EmployeeName = "John Doe",
                ExpirationDate = DateTime.Now.AddMonths(1),
                IsActive = true
            };

            var mockPassRepository = new Mock<IPassRepository>();
            mockPassRepository
                .Setup(repo => repo.GetActivePasses())
                .Returns(new List<Pass> { expectedPass });

            mockUnitOfWork.Setup(u => u.PassRepository).Returns(mockPassRepository.Object);

            return new PassService(mockUnitOfWork.Object);
        }
    }
}
