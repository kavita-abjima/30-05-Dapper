using DapperCrudOperations;

namespace DapperOperations.Services
{
    public interface IDapper
    {
        Task<List<Student>> GetStudent();

        Task<Student> GetStudentById(int id);

        Task<Student> AddStudentAsync(Student student);

        Task<Student> DeleteEmployeeAsync(int id);

        Task<Student> UpdateStudentAsync(int id, Student student);
    }
}

