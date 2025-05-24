using Moq;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Controllers;
using StudentAPI.Models;
using StudentAPI.Services;
using Xunit;
using Newtonsoft.Json.Linq;

public class StudentControllerTests
{
    //PRUEBAS UNITARIAS UTILIZANDO MOCKs
    // Para realizar pruebas unitarias de la clase StudentController, se utiliza un mock del servicio IStudentService.
    // Esto permite simular el comportamiento del servicio.

    private readonly Mock<IStudentService> _mockService;
    private readonly StudentController _controller;

    public StudentControllerTests()
    {
        _mockService = new Mock<IStudentService>();
        _controller = new StudentController(_mockService.Object);
    }
    [Fact]
    public void Aprobo_DeberiaRetornar_True_CuandoNotaEsMayorA51()
    {
        /// Arrange
        var estudiante = new Estudiante { CI = 123, Nombre = "Ana", Nota = 70 };
        _mockService.Setup(service => service.HasApproved(estudiante)).Returns(true);

        // Act
        var resultado = _controller.Aprobo(estudiante);
        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var respuesta = JObject.FromObject(okResult.Value!);

        // Assert
        Assert.True((bool)respuesta["aprobado"]!);
    }

    [Fact]
    public void ValidarNombre_DeberiaRetornarTrue_SiNombreCoincide()
    {
        // Arrange
        var estudiante = new Estudiante { CI = 123, Nombre = "Ana", Nota = 70 };
        var nombreIngresado = "Ana";

        _mockService.Setup(service => service.ValidateName(estudiante, nombreIngresado)).Returns(true);

        // Act
        var resultado = _controller.ValidarNombre(estudiante, nombreIngresado);
        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var respuesta = JObject.FromObject(okResult.Value!);

        // Assert
        Assert.True((bool)respuesta["nombreCorrecto"]!);
    }

    [Fact]
    public void ValidarCI_DeberiaRetornarFalse_SiNoCoincide()
    {
        // Arrange
        var estudiante = new Estudiante { CI = 123, Nombre = "Ana", Nota = 70 };
        var ciIngresado = 999; // no coincide con el CI del estudiante

        _mockService.Setup(service => service.ValidateCI(estudiante, ciIngresado)).Returns(false);

        // Act
        var resultado = _controller.ValidarCI(estudiante, ciIngresado);
        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var respuesta = JObject.FromObject(okResult.Value!);

        // Assert
        Assert.False((bool)respuesta["ciCorrecto"]!);
    }
}