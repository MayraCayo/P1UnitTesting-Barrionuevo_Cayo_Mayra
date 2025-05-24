using Microsoft.AspNetCore.Mvc;
using StudentAPI.Controllers;
using StudentAPI.Models;
using Xunit;
using Newtonsoft.Json.Linq;

public class StudentControllerTestsStub
{
    private readonly StudentController _controller;

    //Se esta utilizando un stub para el servicio de estudiantes

    public StudentControllerTestsStub()
    {
        var stubService = new StubStudentService();
        _controller = new StudentController(stubService);
    }

    [Fact]
    public void ValidarNombre_DeberiaRetornar_True_SiNombreCoincide()
    {
        // Arrange
        var estudiante = new Estudiante { Nombre = "Mayra" };
        var controller = new StudentController(new StubStudentService());

        // Act
        var resultado = controller.ValidarNombre(estudiante, "Mayra");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(resultado);
        var json = JObject.FromObject(okResult.Value!);
        Assert.True((bool)json["nombreCorrecto"]!);
    }

    [Fact]
    public void ValidarCI_DeberiaRetornar_True_SiCICoincide()
    {
        /// Arrange
    var estudiante = new Estudiante { CI = 123456 };
    var controller = new StudentController(new StubStudentService());

    // Act
    var resultado = controller.ValidarCI(estudiante, 123456);

    // Assert
    var okResult = Assert.IsType<OkObjectResult>(resultado);
    var json = JObject.FromObject(okResult.Value!);
    Assert.True((bool)json["ciCorrecto"]!);
    }
}