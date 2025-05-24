using StudentAPI.Models;

namespace StudentAPI.Services
{
    public class StudentService : IStudentService
    {
        public bool HasApproved(Estudiante estudiante)
        {
            return estudiante.Nota >= 51;
        }

        public bool ValidateName(Estudiante estudiante, string nombreIngresado)
        {
            return estudiante.Nombre == nombreIngresado;
        }

        public bool ValidateCI(Estudiante estudiante, int ciIngresado)
        {
            return estudiante.CI == ciIngresado;
        }
    }
}