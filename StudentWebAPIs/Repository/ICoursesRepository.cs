using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Repository
{
    public interface ICoursesRepository
    {
        Task<IEnumerable<Courses>> GetAllCourses();
        Task<Courses> GetCoursesById(Guid id);
        Task<bool> AddCourses(Courses courses);
        Task<bool> DeleteCourses(Guid id);
        Task<bool> UpdateCourses(Courses courses, Guid Id);
    }
}
