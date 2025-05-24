using Xunit;
using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Tests.Services
{
    public class StudentServiceTests
    {
        private StudentService _service;

        public StudentServiceTests()
        {
        _service = new StudentService();
       }
    
        // Pruebas unitarias para la clase StudentService

        [Fact]
        public void HasApproved_ReturnsTrue_WhenNotaIs51OrMore()
        {
            // Arrange
            var estudiante = new Estudiante { Nota = 60 };

            // Act
            var resultado = _service.HasApproved(estudiante);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void HasApproved_ReturnsFalse_WhenNotaIsLessThan51()
        {
            // Arrange
            var estudiante = new Estudiante { Nota = 40 };

            // Act
            var resultado = _service.HasApproved(estudiante);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void ValidateName_ReturnsTrue_WhenNameMatches()
        {
            // Arrange
            var estudiante = new Estudiante { Nombre = "Mayra" };
            string nombreIngresado = "Mayra";

            // Act
            var resultado = _service.ValidateName(estudiante, nombreIngresado);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void ValidateName_ReturnsFalse_WhenNameDoesNotMatch()
        {
            // Arrange
            var estudiante = new Estudiante { Nombre = "Carlos" };
            string nombreIngresado = "Juan";

            // Act
            var resultado = _service.ValidateName(estudiante, nombreIngresado);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void ValidateCI_ReturnsTrue_WhenCIIsCorrect()
        {
            // Arrange
            var estudiante = new Estudiante { CI = 123456 };
            int ciIngresado = 123456;

            // Act
            var resultado = _service.ValidateCI(estudiante, ciIngresado);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void ValidateCI_ReturnsFalse_WhenCIIsIncorrect()
        {
            // Arrange
            var estudiante = new Estudiante { CI = 123456 };
            int ciIngresado = 654321;

            // Act
            var resultado = _service.ValidateCI(estudiante, ciIngresado);

            // Assert
            Assert.False(resultado);
        }
    }
}
