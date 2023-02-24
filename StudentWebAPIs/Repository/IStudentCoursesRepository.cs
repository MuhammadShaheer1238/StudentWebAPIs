using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Repository
{
    public interface IStudentCoursesRepository
    {
        Task<IEnumerable<StudentCourses>> GetAllStudentCourses();
        Task<StudentCourses> GetStudentCourseById(Guid id);
        Task<bool> AddStudentCourse(StudentCourses studentCourses);
        Task<bool> DeleteStudentCourse(Guid id);
        Task<bool> UpdateStudentCourse(StudentCourses studentCourses, Guid id);
    }
}
