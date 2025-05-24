using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Services;


namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("has-approved")]
        public IActionResult Aprobo([FromBody] Estudiante estudiante)
        {
            var resultado = _studentService.HasApproved(estudiante);
            return Ok(new { aprobado = resultado });
        }

        [HttpPost("validar-nombre")]
        public IActionResult ValidarNombre([FromBody] Estudiante estudiante, [FromQuery] string nombre)
        {
        var resultado = _studentService.ValidateName(estudiante, nombre);
        return Ok(new { nombreCorrecto = resultado });
        }

        [HttpPost("validar-ci")]
        public IActionResult ValidarCI([FromBody] Estudiante estudiante, [FromQuery] int ci)
        {
        var resultado = _studentService.ValidateCI(estudiante, ci);
        return Ok(new { ciCorrecto = resultado });
        }
    }
}