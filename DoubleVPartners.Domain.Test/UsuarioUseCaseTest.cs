using DoubleVPartners.Domain.Exceptions;
using DoubleVPartners.Domain.IRepository;
using DoubleVPartners.Domain.Model;
using DoubleVPartners.Domain.UseCase;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DoubleVPartners.Domain.Test
{
    [TestClass]
    public class UsuarioUseCaseTest
    {
        [TestMethod]
        public async Task CreateUserFull()
        {
            // Arrange
            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(repo => repo.ValidatUsereAsync(It.IsAny<string>())).ReturnsAsync(true);
            mockRepository.Setup(repo => repo.CreateUserAsync(It.IsAny<UsuarioModel>())).ReturnsAsync(new UsuarioModel { Id = 1, Usuario = "carla@correo.com", Pass = "123456"});

            var useCase = new UsuarioUseCase(mockRepository.Object);
            var usuarioModel = new UsuarioModel { Usuario = "carla@correo.com", Pass = "123456" };

            // Act
            var result = await useCase.CreateUser(usuarioModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("carla@correo.com", result.Usuario);
            Assert.AreEqual("123456", result.Pass);
        }

        [TestMethod]
        public async Task CreateUser_NoExist()
        {
            // Arrange
            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(repo => repo.ValidatUsereAsync(It.IsAny<string>())).ReturnsAsync(false);
            mockRepository.Setup(repo => repo.CreateUserAsync(It.IsAny<UsuarioModel>())).ReturnsAsync(new UsuarioModel { Id = 1, Usuario = "carla@correo.com", Pass = "123456" });

            var useCase = new UsuarioUseCase(mockRepository.Object);
            var usuarioModel = new UsuarioModel { Usuario = "carla@correo.com", Pass = "123456" };

            // Act & Assert
            var error = await Assert.ThrowsExceptionAsync<DomainValidateException>(async () => await useCase.CreateUser(usuarioModel));
            Assert.AreEqual("Ya existe un registro con este usuario.", error.Message);
        }

        [TestMethod]
        public async Task Login_Correct()
        {
            // Arrange
            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(repo => repo.ValidateLoginAsync(It.IsAny<LoginModel>())).ReturnsAsync(new UsuarioModel { Id = 1, Usuario = "carla@correo.com", Pass = "123456" });

            var useCase = new UsuarioUseCase(mockRepository.Object);
            var loginModel = new LoginModel { Usuario = "carla@correo.com", Pass = "123456" };

            // Act
            var result = await useCase.Login(loginModel);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task Login_CredntialIncorrect()
        {
            // Arrange
            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(repo => repo.ValidateLoginAsync(It.IsAny<LoginModel>())).ReturnsAsync((UsuarioModel)null);

            var useCase = new UsuarioUseCase(mockRepository.Object);
            var loginModel = new LoginModel { Usuario = "user@correo.com", Pass = "555555" };

            // Act & Assert
            var error = await Assert.ThrowsExceptionAsync<DomainValidateException>(async () => await useCase.Login(loginModel));
            Assert.AreEqual("Usuario o contraseña incorrectos.", error.Message);
        }
    }
}
