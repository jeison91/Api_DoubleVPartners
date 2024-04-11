using DoubleVPartners.Domain.Exceptions;
using DoubleVPartners.Domain.IRepository;
using DoubleVPartners.Domain.Model;
using DoubleVPartners.Domain.UseCase;
using Moq;

namespace DoubleVPartners.Domain.Test
{
    [TestClass]
    public class PeronaUseCaseTest
    {
        [TestMethod]
        public async Task CreatePersonFull()
        {
            // Arrange
            var mockRepository = new Mock<IPersonaRepository>();
            mockRepository.Setup(repo => repo.ValidatePersonAsync(It.IsAny<string>())).ReturnsAsync(true);
            mockRepository.Setup(repo => repo.CreatePersonAsync(It.IsAny<PersonaModel>())).ReturnsAsync(new PersonaModel { Id = 1, IdTipoIdentificacion = 13, Identificacion = "1102", Nombres = "Carla", Apellidos = "Alzate", Email = "carla@correo.com" });

            var useCase = new PersonaUseCase(mockRepository.Object);
            var personaModel = new PersonaModel { IdTipoIdentificacion = 13, Identificacion = "1102", Nombres = "Carla", Apellidos = "Alzate", Email = "carla@correo.com" };

            // Act
            var result = await useCase.CreatePerson(personaModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("1102", result.Identificacion);
            Assert.AreEqual("Carla", result.Nombres);
            Assert.AreEqual("Alzate", result.Apellidos);
            Assert.AreEqual("carla@correo.com", result.Email);
        }

        [TestMethod]
        public async Task CreatePerson_NoExist()
        {
            var mockRepository = new Mock<IPersonaRepository>();
            mockRepository.Setup(repo => repo.ValidatePersonAsync(It.IsAny<string>())).ReturnsAsync(false);

            var useCase = new PersonaUseCase(mockRepository.Object);
            var personaModel = new PersonaModel { IdTipoIdentificacion = 13, Identificacion = "1128", Nombres = "Jeison", Apellidos = "Cañas", Email = "jeison@correo.com"  };

            // Act & Assert
            var error = await Assert.ThrowsExceptionAsync<DomainValidateException>(async () => await useCase.CreatePerson(personaModel));

            Assert.AreEqual("Una persona con esta identificación ya está registrada.", error.Message);
        }

        [TestMethod]
        public async Task ListPerson()
        {
            // Arrange
            var mockRepository = new Mock<IPersonaRepository>();
            mockRepository.Setup(repo => repo.ListPersonAsync()).ReturnsAsync(new List<PersonaModel> {
                new PersonaModel { IdTipoIdentificacion = 13, Identificacion = "1128", Nombres = "Jeison", Apellidos = "Cañas", Email = "jeison@correo.com", tipoIdentificacion = new TipoIdentificacionModel { Id = 13, Descripcion = "Cédula de ciudadanía"} },
                new PersonaModel { IdTipoIdentificacion = 13, Identificacion = "1102", Nombres = "Carla", Apellidos = "Alzate", Email = "carla@correo.com", tipoIdentificacion = new TipoIdentificacionModel { Id = 13, Descripcion = "Cédula de ciudadanía"}  },
            });

            var useCase = new PersonaUseCase(mockRepository.Object);

            // Act
            var result = await useCase.ListPerson();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("1128", result[0].Identificacion);
            Assert.AreEqual("Jeison", result[0].Nombres);
        }
    }
}