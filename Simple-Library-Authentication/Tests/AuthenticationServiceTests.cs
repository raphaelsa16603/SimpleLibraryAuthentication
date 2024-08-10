using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleLibraryAuthentication.Interfaces;
using SimpleLibraryAuthentication.Models;
using SimpleLibraryAuthentication.Services;

namespace SimpleLibraryAuthentication.Tests
{
    /// <summary>
    /// Classe de testes unitários para AuthenticationService.
    /// </summary>
    [TestClass]
    public class AuthenticationServiceTests
    {
        private Mock<IHashingService> _mockHashingService;
        private Mock<IUserRepository> _mockUserRepository;
        private AuthenticationService _authenticationService;

        [TestInitialize]
        public void SetUp()
        {
            _mockHashingService = new Mock<IHashingService>();
            _mockUserRepository = new Mock<IUserRepository>();
            _authenticationService = new AuthenticationService(_mockHashingService.Object, _mockUserRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_ShouldThrowException_WhenUsernameIsNullOrEmpty()
        {
            _authenticationService.RegisterUser(null, "password");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_ShouldThrowException_WhenPasswordIsNullOrEmpty()
        {
            _authenticationService.RegisterUser("username", null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterUser_ShouldThrowException_WhenUsernameAlreadyExists()
        {
            _mockUserRepository.Setup(repo => repo.GetUserByUsername(It.IsAny<string>())).Returns(new User());

            _authenticationService.RegisterUser("username", "password");
        }

        [TestMethod]
        public void RegisterUser_ShouldReturnTrue_WhenUserIsRegisteredSuccessfully()
        {
            _mockUserRepository.Setup(repo => repo.GetUserByUsername(It.IsAny<string>())).Returns((User)null);
            _mockHashingService.Setup(service => service.HashPassword(It.IsAny<string>())).Returns("hashedPassword");

            var result = _authenticationService.RegisterUser("username", "password");

            Assert.IsTrue(result);
            _mockUserRepository.Verify(repo => repo.SaveUser(It.IsAny<User>()), Times.Once);
        }

        [TestMethod]
        public void LoginUser_ShouldReturnFalse_WhenUserDoesNotExist()
        {
            _mockUserRepository.Setup(repo => repo.GetUserByUsername(It.IsAny<string>())).Returns((User)null);

            var result = _authenticationService.LoginUser("username", "password");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoginUser_ShouldReturnFalse_WhenPasswordDoesNotMatch()
        {
            _mockUserRepository.Setup(repo => repo.GetUserByUsername(It.IsAny<string>())).Returns(new User { Username = "username", PasswordHash = "hashedPassword" });
            _mockHashingService.Setup(service => service.VerifyPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            var result = _authenticationService.LoginUser("username", "password");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoginUser_ShouldReturnTrue_WhenPasswordMatches()
        {
            _mockUserRepository.Setup(repo => repo.GetUserByUsername(It.IsAny<string>())).Returns(new User { Username = "username", PasswordHash = "hashedPassword" });
            _mockHashingService.Setup(service => service.VerifyPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var result = _authenticationService.LoginUser("username", "password");

            Assert.IsTrue(result);
        }
    }
}
