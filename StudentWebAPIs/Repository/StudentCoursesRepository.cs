using Microsoft.EntityFrameworkCore;
using StudentWebAPIs.Data;
using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Repository
{
    public class StudentCoursesRepository : IStudentCoursesRepository
    {
        public readonly StudentDbContext _studentDbContext;
        public StudentCoursesRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        

        public async Task<bool> AddStudentCourse(StudentCourses studentCourses)
        {
            if(studentCourses != null)
            {
                await _studentDbContext.studentCourses.AddAsync(studentCourses);
                await _studentDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteStudentCourse(Guid id)
        {
            var result = await _studentDbContext.studentCourses.Where(x => x.Id == id).FirstOrDefaultAsync();

            if(result != null)
            {
                _studentDbContext.studentCourses.Remove(result);
                await _studentDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<StudentCourses>> GetAllStudentCourses()
        {
            var result = await _studentDbContext.studentCourses.ToListAsync();
            return result;
        }

        public async Task<StudentCourses> GetStudentCourseById(Guid id)
        {
            var result = await _studentDbContext.studentCourses.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateStudentCourse(StudentCourses studentCourses, Guid id)
        {
            var result = await _studentDbContext.studentCourses.Where(x => x.Id == id).FirstOrDefaultAsync();

            if(result!= null)
            {
                result.StudentId = studentCourses.StudentId;
                result.CourseId = studentCourses.CourseId;

                _studentDbContext.studentCourses.Update(result);
                await _studentDbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
