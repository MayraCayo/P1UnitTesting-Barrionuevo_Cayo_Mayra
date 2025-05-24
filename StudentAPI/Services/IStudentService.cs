using StudentAPI.Models;


namespace StudentAPI.Services
{
    public interface IStudentService
    {
        bool HasApproved(Estudiante estudiante);
        bool ValidateName(Estudiante estudiante, string nombreIngresado);
        bool ValidateCI(Estudiante estudiante, int ciIngresado);
    }
}