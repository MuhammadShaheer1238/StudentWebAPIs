using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Repository
{
    public interface IInstructorRepository
    {
        Task<IEnumerable<Instructors>> GetAllInstructors();
        Task<Instructors> GetInstructorById(Guid id);
        Task<bool> AddInstructor(Instructors instructor);
        Task<bool> DeleteInstructor(Guid id);
        Task<bool> UpdateInstructor(Instructors instructors, Guid id);
    }
}
