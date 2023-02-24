using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudent();
        Task<Student> GetStudentById(Guid Id);
        Task<bool> AddStudent(Student student);
        Task<bool> DeleteStudent(Guid Id);
        Task<bool> UpdateStudent(Student student, Guid Id);
    }
}
